using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace www.Models
{
    public class TipViewManager
    {
        public static Task<rest_api.Models.Tip[]> GetRandomTips(int count)
        {
            string apiPath = $"random/{count}";
            return GetTips(apiPath);
        }

        public static Task<rest_api.Models.Tip[]> GetSearchTips(string term)
        {
            string apiPath = $"search/{term}";
            return GetTips(apiPath);
        }

        public static Task<rest_api.Models.Tip[]> GetTipsByTag(string tag)
        {
            string apiPath = $"tag/{tag}";
            return GetTips(apiPath);
        }

        private static async Task<rest_api.Models.Tip[]> GetTips(string apiPath)
        {
            rest_api.Models.Tip[] tips = null;
            apiPath = $"api/tips/{apiPath}";

            using (var client = new HttpClient())
            {
                client.BaseAddress = Global.ServiceBaseUri;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                               
                HttpResponseMessage response = await client.GetAsync(apiPath);
                if (response.IsSuccessStatusCode)
                {
                    tips = await response.Content.ReadAsAsync<rest_api.Models.Tip[]>();
                }
            }

            return tips;
        }

    }
}
