using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;

namespace toDo1
{
    class Program
    {
        static void Main()
        {
            const string myUrl = "https://www.boredapi.com/api/activity";
            HttpClient client = new HttpClient();

            while (true)
            {
                var result = client.GetStringAsync(myUrl).Result;
                var bored = (Bored)JsonConvert.DeserializeObject(result, typeof(Bored));
                
                Console.WriteLine("~If you are BORED, hit enter to get new idea~");
                Console.ReadLine();
                Console.WriteLine(bored.Activity + "\n");
            }
        }

        public class Bored
        {
            public string Activity { get; set; }
        }
    }
}
