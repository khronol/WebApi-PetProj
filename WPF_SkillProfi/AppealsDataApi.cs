using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SkillProfi_WPF
{
    class AppealsDataApi
    {
        private HttpClient HttpClient { get; set; }
        public AppealsDataApi()
        {
            HttpClient = new HttpClient();
        }

        public void AddAppeal(Appeals appeals)
        {
            string url = @"https://localhost:7033/api/values";

            var r = HttpClient.PostAsync(
                requestUri: url,
                content: new StringContent(JsonConvert.SerializeObject(appeals), Encoding.UTF8,
                mediaType: "application/json")
                ).Result;
        }
        public IEnumerable<Appeals> GetAppeals()
        {
            string url = @"https://localhost:7033/api/values";

            string json = HttpClient.GetStringAsync(url).Result;
            return JsonConvert.DeserializeObject<IEnumerable<Appeals>>(json);
        }
    }
}
