using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rest_api
{
    public class Global
    {
        public static string DataDirectory;
        public static Models.TipManager Tips;
        public static Random RandomGenerator;
        static Global()
        {
            DataDirectory = AppDomain.CurrentDomain.GetData("DataDirectory").ToString();
            Tips = Models.TipManager.LoadAllTips();
            RandomGenerator = new Random(DateTime.Now.Millisecond);
        }

        public static IEnumerable<TValue> RandomValues<TKey, TValue>(IDictionary<TKey, TValue> dict)
        {
            Random rand = new Random();
            List<TValue> values = Enumerable.ToList(dict.Values);
            int size = dict.Count;
            while (true)
            {
                yield return values[rand.Next(size)];
            }
        }
    }
}
