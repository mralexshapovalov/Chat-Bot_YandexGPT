using System;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
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
            Console.WriteLine("Это чат-бот работает на базе Yandex GPT");
            while (true)
            {
                Console.Write("Вопрос : ");
                Console.WriteLine("Ответ : " + await HTTPClient.MAsync(Promt.PromtRequest(), URLKey.ApiKey, URLKey.Url)); 
            }
        }
    }
}
