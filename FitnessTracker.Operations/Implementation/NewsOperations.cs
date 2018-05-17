﻿using FitnessTracker.Operations.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessTracker.DataModel;
using System.Net.Http;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace FitnessTracker.Operations.Implementation
{
    public class NewsOperations : INewsOperations
    {
        private readonly string apiKey = "5cf0ee4070bc4d38ab89ea05bec9935a";
        private readonly string url = "https://newsapi.org/v2/everything?sources=nfl-news&sortBy=popularity&language=en&apiKey=";

        public ICollection<NewsModel> GetNews()
        {
            //using (StreamReader reader = new StreamReader("D:/news.txt"))
            //{
            //    var jsonString = reader.ReadToEnd();

            //    return JsonConvert.DeserializeObject<ICollection<NewsModel>>(jsonString);
            //}

            var result = new List<NewsModel>();
            WebRequest request = WebRequest.Create($"{url}{apiKey}");
            using (StreamReader objReader = new StreamReader(request.GetResponse().GetResponseStream()))
            {
                var json = JObject.Parse(objReader.ReadToEnd());
                var articles = json.GetValue("articles");

                foreach (var item in articles)
                {
                    result.Add(JsonConvert.DeserializeObject<NewsModel>(item.ToString()));
                }
            }
            using (StreamWriter file = File.CreateText(@"D:\news.txt"))
            {
                JsonSerializer serializer = new JsonSerializer();

                serializer.Serialize(file, result);
            }
            return result;
        }
    }
}