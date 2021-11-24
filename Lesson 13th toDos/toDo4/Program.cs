using System;
using System.Diagnostics;

namespace toDo4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter how much minute after you want your computer to shut down");

            int minute = int.Parse(Console.ReadLine());

            int ConvertMinToSec(int minute)
            {
                int second = minute * 60;
                return second;
            }

            Process.Start("shutdown", $"/s /t {ConvertMinToSec(minute)}");
        }
    }
}
