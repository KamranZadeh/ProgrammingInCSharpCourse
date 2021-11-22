using System;
using System.IO;

namespace toDo2
{
    class Program
    {
        public static void Main()
        {
            const string myFolder2 = @"D:\myFolder2";

            var myPath = Directory.CreateDirectory(myFolder2);

            User user = new User
            {
                Name = Console.ReadLine(),
                Surname = Console.ReadLine(),
                Gender = Console.ReadLine()
            };

            var file = Path.Combine(myPath.ToString(), user.Name + ".doc");

            var fileText = $"Name: {user.Name}\n" +
                $"Surname: {user.Surname}\n" +
                $"Gender: {user.Gender}";

            File.WriteAllText(file, fileText);

            string[] lines = File.ReadAllLines(file);

            Console.WriteLine($"The content of the last line of the file {Path.GetFileName(file)} is: '{lines[2]}'");
        }

        public class User
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Gender { get; set; }
        }

    }
}
