using System;
using System.Collections.Generic;
using System.IO;

namespace DataConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputGroupFolder = @"C:\src\HotTips\HotTips\Groups";
            string inputTipFolder = @"C:\src\HotTips\HotTips\Tips";
            string outputFolder = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), @"out");
            Directory.CreateDirectory(outputFolder);


            string[] files = Directory.GetFiles(inputGroupFolder, "*.json");


            foreach (string file in files)
            {
                TipGroup tipGroup = TipGroup.FromJson(File.ReadAllText(file));
                foreach (Tip tip in tipGroup.Tips)
                {
                    rest_api.Models.Tip tipToAdd = new rest_api.Models.Tip();

                    tipToAdd.Id = tip.TipId;
                    tipToAdd.Name = tip.Name;
                    tipToAdd.Markdown = File.ReadAllText(Path.Combine(inputTipFolder, tip.Content));
                    tipToAdd.Tags = new List<string>();
                    tipToAdd.Tags.Add(tipGroup.GroupName);
                    tipToAdd.Scope = "";
                    tipToAdd.Keys = new List<string>();
                    tipToAdd.VsMinVer = "15.*";
                    tipToAdd.VsMaxVer = "";
                    tipToAdd.GifUri = "";
                    tipToAdd.VideoUri = "";
                    tipToAdd.ImageBase64 = "";

                    Console.WriteLine($"Writting json file for {tipToAdd.Id}");

                    string filename = string.Format("{0}.json", tipToAdd.Id);
                    File.WriteAllText(Path.Combine(outputFolder, filename), rest_api.Models.Serialize.ToJson(tipToAdd));
                }
            }

                /*
                string[] files = Directory.GetFiles(inputTipFolder, "*.md");

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
                */

                Console.WriteLine($"All files written to {outputFolder}");
            Console.ReadLine();
        }
    }
}
