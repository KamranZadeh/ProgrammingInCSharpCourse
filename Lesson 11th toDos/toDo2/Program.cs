using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;

namespace toDo2
{
    class Program
    {
        static void Main()
        {
            HttpClient client = new();
            
            while (true)
            {
                string name = Console.ReadLine();
                string myUrl = $"https://api.genderize.io?name={name}";
                var result = client.GetStringAsync(myUrl).Result;
                var genderize = (Genderize)JsonConvert.DeserializeObject(result, typeof(Genderize));

                Console.WriteLine(genderize.Gender);
            }
        }

        public class Genderize
        {
            public string Name { get; set; }
            public string Gender { get; set; }
        }
    }
}
