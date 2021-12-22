using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace toDo2
{
    class Program
    {
        static async Task Main(string[] args)
        {
            const string catFactUrl = "https://catfact.ninja/fact";

            Console.WriteLine("You will get a fact about cats\n");

            while (true)
            {
                HttpClient client = new();
                var result = await client.GetStringAsync(catFactUrl);
                var catFact = JsonConvert.DeserializeObject<CatFact>(result);

                Console.WriteLine(catFact.Fact + "\n");
                Thread.Sleep(1000);
                Console.WriteLine("If you wish hit enter to get more infos about cats");
                Console.ReadLine();
            }
            
        }
    }

    public class CatFact
    {
        public string Fact { get; set; }
        public int Lenght { get; set; }
    }
}
