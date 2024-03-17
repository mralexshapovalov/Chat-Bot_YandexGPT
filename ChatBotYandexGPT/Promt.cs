using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatBotYandexGPT
{
    public static class Promt
    {
        public static object PromtRequest()
        {
            var prompt = new
            {
                modelUri = "gpt://b1gnhp30ce0i8c5b3l7d/yandexgpt-lite",
                completionOptions = new
                {
                    stream = false,
                    temperature = 0.6,
                    maxTokens = "2000"
                },
                messages = new[]
                {
                  new
                  {
                     role = "user",
                     text = Console.ReadLine()
                   }
                }
            };
            return prompt;
        }
    }
}
