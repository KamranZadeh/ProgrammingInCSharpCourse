using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Net.Http;

namespace toDo3
{
    class Program
    {
        static void Main()
        {
            var client = new HttpClient();

            while (true)
            {
                Console.WriteLine("Enter a name to know where this person from with some probability\n");
                string name = Console.ReadLine();
                string myApiUrl = $"https://api.nationalize.io?name={name}";

                var JsonResult = client.GetStringAsync(myApiUrl).Result;

                Root result = JsonConvert.DeserializeObject<Root>(JsonResult);

                foreach (var input in result.country)
                {
                    Console.WriteLine($"Entered name: '{name}' is from this country ID '{input.country_id}' with {input.probability.ToString("0.000")} probability");
                }
                Console.WriteLine();
            }
        }

        public class Country
        {
            public string country_id { get; set; }
            public double probability { get; set; }
        }

        public class Root
        {
            public string name { get; set; }
            public Country[] country { get; set; }
        }
    }
}
