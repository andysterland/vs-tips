using System;
using System.Collections.Generic;
using System.IO;
using rest_api.Models;

namespace DataConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFolder = @"C:\src\HotTips\HotTips\Tips";
            string outputFolder = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), @"out");
            Directory.CreateDirectory(outputFolder);
            string[] files = Directory.GetFiles(inputFolder, "*.md");

            foreach(string file in files)
            {
                Tip tip = new Tip();
                tip.Id = Path.GetFileNameWithoutExtension(file);
                tip.Markdown = File.ReadAllText(file);
                tip.Scope = "";
                tip.Tags = new List<string>();

                if(tip.Id.Contains("EDI"))
                {
                    tip.Scope = "editor";
                    tip.Tags.Add("editor");
                }
                if (tip.Id.Contains("NAV"))
                {
                    tip.Scope = "global";
                    tip.Tags.Add("navigation");
                }
                if (tip.Id.Contains("SHL"))
                {
                    tip.Scope = "global";
                    tip.Tags.Add("shell");
                }
                
                string json = tip.ToJson();

                string filename = string.Format("{0}.json", tip.Id);

                Console.WriteLine($"Writting json file for {tip.Id}");
                File.WriteAllText(Path.Combine(outputFolder, filename), json);
            }
            Console.WriteLine($"All files written to {outputFolder}");
            Console.ReadLine();
        }
    }
}
