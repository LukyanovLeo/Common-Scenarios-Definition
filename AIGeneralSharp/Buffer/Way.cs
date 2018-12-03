using AIGeneralSharp.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AIGeneralSharp.Buffer
{
    static class Way
    {
        public static List<Params> Target = new List<Params>();
        public static List<Params> Initial = new List<Params>();
        public static List<Params> Current = new List<Params>();
        public static List<Operation> Operations = new List<Operation>();

        public static void Initialize(string targetPath, string initialPath, string opsPath)
        {
            Target = JsonConvert.DeserializeObject<List<Params>>
                (File.ReadAllText(Path.Combine(EnvConfig.CurrentDir, targetPath), Encoding.Default));
            Initial = JsonConvert.DeserializeObject<List<Params>>
                (File.ReadAllText(Path.Combine(EnvConfig.CurrentDir, initialPath), Encoding.Default));
            Current = JsonConvert.DeserializeObject<List<Params>>
                (File.ReadAllText(Path.Combine(EnvConfig.CurrentDir, initialPath), Encoding.Default));
            Operations = JsonConvert.DeserializeObject<List<Operation>>
                (File.ReadAllText(Path.Combine(EnvConfig.CurrentDir, opsPath), Encoding.Default));
        }

        // TODO: этот метод должен находится здесь?
        public static string Check()
        {
            string error = "";
            if (Target.Count < 1)
                error += "Target state is empty\n";
            if (Initial.Count < 1)
                error += "Initial state is empty\n";
            if (Operations.Count < 1)
                error += "Operation list is empty";
            return error;
        }
    }
}
