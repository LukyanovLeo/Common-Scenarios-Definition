using AIGeneralSharp.Buffer;
using AIGeneralSharp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AIGeneralSharp
{
    public class Helper
    {
        public static List<Operation> GetAvailableOperations(List<Operation> operations)
        {
            var way = new List<Operation>();
            while (operations.Any())
            {
                foreach (var operation in GetProperOperation(operations))
                    way.Add(operation);
                operations = operations.Except(way).ToList();
            }
            return way;
        }

        // TODO: переименовать нижеописанные методы
        public static List<Operation> GetProperOperation(List<Operation> operations)
        {
            var properOperations = new List<Operation>();

            for (int i = Way.Initial.Count; i >= 0; i--)
            {
                bool isFound = false;
                foreach (var operation in operations)
                {
                    if (Except(operation.Post, Way.Target).Count() == i &&
                        IsNotIntPreConditions(operation, operations))
                    {
                        properOperations.Add(operation);
                        isFound = true;
                    }
                }
                if (isFound)
                    break;
            }
            return properOperations;
        }

        public static Operation GetProperOperationFirst(ref List<Operation> operations)
        {
            var properOperations = new List<Operation>();
            for (int i = Way.Initial.Count; i >= 0; i--)
            {
                foreach (var operation in operations)
                {
                    if (Intersect(operation.Pre, Way.Target).Count() == i &&
                        Except(operation.Post, Way.Target).Count() == 0 &&
                        IsNotIntPreConditions(operation, operations))
                    {
                        properOperations.Add(operation);
                        UpdateCurrentPre(operation);
                        operations = operations.Except(properOperations).ToList();
                        return operation;
                    }
                }
            }
            return new Operation();
        }

        public static void UpdateCurrentPre(Operation op)
        {
            try
            {
                for (int i = 0; i < op.Pre.Count; i++)
                    if (Way.Current[i] != op.Pre[i])
                        Way.Current[i] = op.Pre[i];
            }
            catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static IEnumerable<Operation> GetWayToTarget()
        {
            var operations = Way.Operations.Select(i => i).ToList();
            var firstOp = GetProperOperationFirst(ref operations);
            if (firstOp.Name != null && firstOp.Pre != null && firstOp.Post != null)
                yield return firstOp;

            for (short i = 0; i < operations.Count; i++)
            {
                var opsToWrite = GetAvailableOperations(operations);
                foreach (var opToWrite in opsToWrite)
                {
                    yield return opToWrite;
                    operations.Remove(opToWrite);
                }
            }
        }

        private static bool IsNotIntPreConditions(Operation targetOp, List<Operation> allOps)
        {
            foreach (var op in allOps)
                foreach (var pre in op.Pre)
                    if (Intersect(targetOp.Post, op.Pre).Count() == targetOp.Post.Count)
                        return false;
            return true;
        }

        private static IEnumerable<Params> Intersect(List<Params> p1, List<Params> p2)
        {
            foreach (var pp1 in p1)
                foreach (var pp2 in p2)
                    if (pp2.Name == pp1.Name && pp2.Value == pp1.Value)
                        yield return pp2;
        }

        private static IEnumerable<Params> Except(List<Params> p1, List<Params> p2)
        {
            foreach (var pp1 in p1)
            {
                bool isMatch = true;
                foreach (var pp2 in p2)
                    if (pp2.Name == pp1.Name && pp2.Value == pp1.Value)
                        isMatch = false;
                if (isMatch)
                    yield return pp1;
            }
        }

        public static List<string> GetCommonSteps()
        {
            var max = Bindings.OperationsLists.Values.Max(item => item.Count);
            var maxOpList = Bindings.OperationsLists.Values.Where(item => item.Count == max).ToList().First();

            var list = new List<string>();
            int counter = 0;
            var text = new StringBuilder();
            for (int i = 0; i < maxOpList.Count; i++)
            {
                int matches = 0;
                foreach (var ops in Bindings.OperationsLists)
                    foreach (var op in ops.Value)
                        if (maxOpList[i].Name == op.Name)
                        {
                            matches++;
                            break;
                        }
                if (matches > Bindings.OperationsLists.Count / 2)
                {
                    text.AppendLine($"{++counter}. {maxOpList[i].Name}");
                    list.Add(maxOpList[i].Name);
                }
            }
            return list;
        }

        public static string GetCommonConditions(List<string> opsNames)
        {
            var text = new StringBuilder();
            foreach (var opName in opsNames)
            {
                var allPres = new List<string>();
                var allPosts = new List<string>();

                int presCounter = 0;
                int postsCounter = 0;

                text.AppendLine($"{opName}");
                foreach (var ops in Bindings.OperationsLists)
                    foreach (var op in ops.Value)
                        if (opName == op.Name)
                        {
                            allPres.AddRange(op.Pre.Select(i => i.Name));
                            presCounter++;

                            allPosts.AddRange(op.Post.Select(i => i.Name));
                            postsCounter++;
                        }

                var uniquePres = allPres.Distinct().ToList();
                text.AppendLine($"\tПредусловия:");
                foreach (var uniquePre in uniquePres)
                {
                    int count = allPres.Count(item => item == uniquePre);
                    if (count > presCounter / 2)
                        text.AppendLine($"\t\t{uniquePre}");
                }
                var uniquePosts = allPosts.Distinct().ToList();
                text.AppendLine($"\tПостусловия:");
                foreach (var uniquePost in uniquePosts)
                {
                    int count = allPosts.Count(item => item == uniquePost);
                    if (count > postsCounter / 2)
                        text.AppendLine($"\t\t{uniquePost}");
                }
            }
            return text.ToString();
        }

        private static IEnumerable<Operation> Except(List<Operation> op1, List<Operation> op2)
        {
            foreach (var oop1 in op1)
            {
                bool isMatch = true;
                foreach (var oop2 in op2)
                    if (oop2.Name == oop1.Name)
                        isMatch = false;
                if (isMatch)
                    yield return oop1;
            }
        }


        public static int LevenshteinDistance(string string1, string string2)
        {
            if (string1 == null)
                throw new ArgumentNullException("string1");
            if (string2 == null)
                throw new ArgumentNullException("string2");
            int diff;
            int[,] m = new int[string1.Length + 1, string2.Length + 1];

            for (int i = 0; i <= string1.Length; i++) { m[i, 0] = i; }
            for (int j = 0; j <= string2.Length; j++) { m[0, j] = j; }

            for (int i = 1; i <= string1.Length; i++)
            {
                for (int j = 1; j <= string2.Length; j++)
                {
                    diff = (string1[i - 1] == string2[j - 1]) ? 0 : 1;

                    m[i, j] = Math.Min(Math.Min(m[i - 1, j] + 1,
                                             m[i, j - 1] + 1),
                                             m[i - 1, j - 1] + diff);
                }
            }
            return m[string1.Length, string2.Length];
        }
    }
}