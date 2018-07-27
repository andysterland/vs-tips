using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace rest_api.Models
{
    public class TipManager
    {
        private Dictionary<string, Tip> _tips;
        private Dictionary<string, List<string>> _tags;
        private Dictionary<string, List<string>> _scope;
        private Dictionary<string, List<string>> _keys;
        public TipManager(  Dictionary<string, Tip> tips,
                            Dictionary<string, List<string>> tags,
                            Dictionary<string, List<string>> scope,
                            Dictionary<string, List<string>> keys)

        {
            _tips = tips;
            _tags = tags;
            _scope = scope;
            _keys = keys;
        }

        public List<Tip> GetAllTips()
        {
            List<Tip> tips = new List<Tip>(_tips.Values);
            return tips;
        }

        public Tip GetTipById(string name)
        {
            return _tips[name];
        }

        public List<Tip> GetTipsByTag(string tag)
        {
            List<Tip> tips = new List<Tip>();
            if (!_tags.ContainsKey(tag))
            {
                return tips;
            }

            foreach(string id in _tags[tag])
            {
                tips.Add(_tips[id]);
            }

            return tips;
        }

        public List<Tip> GetRandomTips(int count)
        {
            IEnumerable<Tip> tipsEnum = Global.RandomValues(_tips).Take(count);            
            return tipsEnum.ToList<Tip>();
        }

        public static TipManager LoadAllTips()
        {
            Dictionary<string, Tip> tips = new Dictionary<string, Tip>();
            Dictionary<string, List<string>> tags = new Dictionary<string, List<string>>();
            Dictionary< string, List<string>> scope = new Dictionary<string, List<string>>();
            Dictionary<string, List<string>> keys = new Dictionary<string, List<string>>();


            string[] files = Directory.GetFiles(Global.DataDirectory, "*.json");

            if (files.Length < 1)
            {
                return null;
            }
            
            foreach (string filename in files)
            {
                string json = File.ReadAllText(filename);
                Tip tip = Tip.FromJson(json);

                tips.Add(tip.Id, tip);

                for (int i = 0; 
                    (tip.Tags != null && tip.Tags.Count > 0) && i < tip.Tags.Count; 
                    i++)
                {
                    if(!tags.ContainsKey(tip.Tags[i]))
                    {
                        tags[tip.Tags[i]] = new List<string>();
                    }
                    tags[tip.Tags[i]].Add(tip.Id);
                }

                if (!scope.ContainsKey(tip.Scope))
                {
                    scope[tip.Scope] = new List<string>();
                }
                scope[tip.Scope].Add(tip.Id);


                for (int i = 0;
                    (tip.Keys != null && tip.Keys.Count > 0) && i < tip.Keys.Count;
                    i++)
                {
                    if (!keys.ContainsKey(tip.Keys[i]))
                    {
                        keys[tip.Keys[i]] = new List<string>();
                    }
                    keys[tip.Keys[i]].Add(tip.Id);
                }
            }

            TipManager tipManager = new TipManager(tips, tags, scope, keys);

            return tipManager;
        }
    }
}