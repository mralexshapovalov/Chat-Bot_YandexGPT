using System;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using System.Net.Http;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;
namespace ChatBotYandexGPT
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var modelUri = "";
            var url = "https://llm.api.cloud.yandex.net/foundationModels/v1/completion";
            var apiKey = "";
            string l = "";
           
            while (true)
            {
                var prompt = new
                {
                    modelUri,
                    completionOptions = new
                    {
                        stream = false,
                        temperature = 0.6,
                        maxTokens = "2000"
                    },
                    messages = new[] {
                    new {
                        role = "user",
                        text = l = Console.ReadLine()
                    }
                 }
                };
                if (l != "!")
                {
                    
               
                    using (var httpClient = new HttpClient())
                    {
                        var json = Newtonsoft.Json.JsonConvert.SerializeObject(prompt);
                        var content = new StringContent(json, Encoding.UTF8, "application/json");
                        httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")); 
                        httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Api-Key", apiKey);
                        var response = await httpClient.PostAsync(url, content);
                        var result = await response.Content.ReadAsStringAsync();
                        
                      
                        
                        string k = result.ToString();
                        Console.WriteLine(k);
                    }
                }
                else
                {
                    break;
                }
            }

        }
    }
}
