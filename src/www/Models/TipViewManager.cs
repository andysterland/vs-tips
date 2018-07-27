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

        public static Task<rest_api.Models.Tip> GetTipById(string id)
        {
            return GetTip(id);
        }

        private static HttpClient GetHttpClient()
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = Global.ServiceBaseUri;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }

        private static async Task<rest_api.Models.Tip> GetTip(string id)
        {
            rest_api.Models.Tip tip = null;
            string apiPath = $"api/tips/{id}";

            using (var client = GetHttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiPath);
                if (response.IsSuccessStatusCode)
                {
                    tip = await response.Content.ReadAsAsync<rest_api.Models.Tip>();
                }
            }

            return tip;
        }

        private static async Task<rest_api.Models.Tip[]> GetTips(string apiPath)
        {
            rest_api.Models.Tip[] tips = null;
            apiPath = $"api/tips/{apiPath}";

            using (var client = GetHttpClient())
            {
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
