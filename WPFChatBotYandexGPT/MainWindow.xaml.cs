﻿using ChatBotYandexGPT_WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace WPFChatBotYandexGPT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TextBoxEnteringText.Text = "Напиши мне...";
            TextBoxEnteringText.Foreground = new SolidColorBrush(Colors.Gray);
        }

        private object TestAsync()
        {
            var prompt = new
            {
                modelUri = "gpt://b1gnhp30ce0i8c5b3l7d/yandexgpt/latest",
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
                     text = TextBoxEnteringText.Text
                   }
                }
            };
            return prompt;
        }

        private async Task<string> GettingData()
        {
            using (var httpClient = new HttpClient())
            {
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(TestAsync());
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Api-Key", "AQVNyJEC3OglIiOsUXafvwK0oQdOfKkdhYOLPEhH");
                var response = await httpClient.PostAsync("https://llm.api.cloud.yandex.net/foundationModels/v1/completion", content);
                var result = await response.Content.ReadAsStringAsync();

                return result;
            }
        }


        private async void RequestText()
        {
            string question = "Вопрос : " + TextBoxEnteringText.Text;
            
            string result = await GettingData();
            result = result.Replace("{\"result\":{\"alternatives\":[{\"message\":{\"role\":\"assistant\",\"text\":\"", String.Empty);
            result = result.Substring(0, result.IndexOf("\"}"));

            string K = result;
            //+"Ответ : " + result;
            K = K.Replace(@"\n", Environment.NewLine);
            ListViewMainText.Items.Add(question);
            ListViewMainText.Items.Add(K);
            TextBoxEnteringText.Text = string.Empty;
        

        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            RequestText();
        }

        private void buttonAddKey(object sender, RoutedEventArgs e)
        {
            AddKeyWindow addKeyWindow = new AddKeyWindow();
            addKeyWindow.Show();
        }

        private void TextBoxEnteringText_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TextBoxEnteringText.Text == "Напиши мне...")
            {
                TextBoxEnteringText.Clear();
                TextBoxEnteringText.Foreground = new SolidColorBrush(Colors.Black);

            }
        }

        private void TextBoxEnteringText_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                RequestText();
            }
        }

        
    }

}
