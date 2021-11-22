using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace _1st_toDo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            const string myApi = "https://www.boredapi.com/api/";
            bool isContinue;
            HttpClient client = new HttpClient();

            do
            {
                var result = await client.GetStringAsync(myApi);
                

                var boredActivity = JsonConvert.DeserializeObject<BoredActivity>(result);
                Console.WriteLine(result);
                Console.WriteLine(boredActivity.activity);

                isContinue = Convert.ToBoolean(Console.ReadLine());
            } while (isContinue);



        }

        public class BoredActivity
        {
            public string activity { get; set; }
            public string Type { get; set; }
            public int Price { get; set; }
            public string Link { get; set; }
            public string Key { get; set; }
            public decimal Accessibility { get; set; }
        }
    }

}
