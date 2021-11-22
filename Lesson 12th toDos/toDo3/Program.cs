using System;

namespace toDo3
{
    class Program
    {
        static void Main()
        {
            const string myFolder = @"D:\myFolder";

            var directories = Directory.GetDirectories(myFolder, "*.*", SearchOption.AllDirectories).Length;
            var filesCount = Directory.GetFiles(myFolder, "*.*", SearchOption.AllDirectories).Length;

            Console.WriteLine(directories + filesCount);
        }
    }
}
