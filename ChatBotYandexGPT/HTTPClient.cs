using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ChatBotYandexGPT
{
    public static class HTTPClient
    {
       public static async Task<string> MAsync(object prompt, string apiKey,string url )
       {
            using (var httpClient = new HttpClient())
            {
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(prompt);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Api-Key", apiKey);
                var response = await httpClient.PostAsync(url, content);
                var result = await response.Content.ReadAsStringAsync();
                result = result.Replace("{\"result\":{\"alternatives\":[{\"message\":{\"role\":\"assistant\",\"text\":\"", String.Empty);
                result = result.Substring(0, result.IndexOf("\"}"));
                return result;
            }
       }
    }
}
