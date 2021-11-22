using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;

namespace toDo4
{
    class Program
    {
        static void Main()
        {
            const string myApiUrl = "https://dog.ceo/api/breeds/image/random";

            var httpClient = new HttpClient();

           
            
            

            string path = @"D:\myFolder\images";
            
            while (true)
            {
                var jsonResult = httpClient.GetStringAsync(myApiUrl).Result;

                Root result = JsonConvert.DeserializeObject<Root>(jsonResult);

                var psi = new ProcessStartInfo();
                psi.UseShellExecute = true;
                Console.WriteLine("Hit enter to go to a dog picture and save the image to your folder");
                Console.ReadLine();
                psi.FileName = result.message;
                Process.Start(psi);
                var webClient = new WebClient();
                webClient.DownloadFile(result.message, path + "\\Dogimage.jpg");
            }
           
        }

        public class Root
        {
            public string message { get; set; }
            public string status { get; set; }
        }


    }
}
