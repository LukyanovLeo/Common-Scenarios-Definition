using AIGeneralSharp.Buffer;
using System.IO;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using AIGeneralSharp.Model;

namespace AIGeneralSharp
{
    public class Bindings
    {
        public static readonly string[] Houses = {
            "Дом",
            "Ещё дом",
            "Сарай",
            "Ещё сарай",
            "Дворец"
        };

        public static Dictionary<string, List<Operation>> OperationsLists = new Dictionary<string, List<Operation>>();

        public static void GetHouseInfo(string name)
        {
            try
            {
                switch (name)
                {
                    case "Дом":
                        if (File.Exists(Path.Combine(EnvConfig.CurrentDir, @"KnowledgeBase\target.json")) &&
                            File.Exists(Path.Combine(EnvConfig.CurrentDir, @"KnowledgeBase\initial.json")) &&
                            File.Exists(Path.Combine(EnvConfig.CurrentDir, @"KnowledgeBase\operations.json")))
                        {
                            Way.Initialize(targetPath: @"KnowledgeBase\target.json",
                                           initialPath: @"KnowledgeBase\initial.json",
                                           opsPath: @"KnowledgeBase\operations.json");
                        }
                        // TODO: сделать, чтобы показывалось, каких файлов нет
                        else
                        {
                            throw new FileNotFoundException();
                        }
                        break;
                    case "Ещё дом":
                        if (File.Exists(Path.Combine(EnvConfig.CurrentDir, @"KnowledgeBase\target2.json")) &&
                            File.Exists(Path.Combine(EnvConfig.CurrentDir, @"KnowledgeBase\initial2.json")) &&
                            File.Exists(Path.Combine(EnvConfig.CurrentDir, @"KnowledgeBase\operations2.json")))
                        {
                            Way.Initialize(targetPath: @"KnowledgeBase\target2.json",
                                           initialPath: @"KnowledgeBase\initial2.json",
                                           opsPath: @"KnowledgeBase\operations2.json");
                        }
                        else
                        {
                            throw new FileNotFoundException();
                        }
                        break;
                    default:
                        MessageBox.Show($"No bindings found for '{name}'", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Some files are missing", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
