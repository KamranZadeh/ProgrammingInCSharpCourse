using System;
using System.Threading;

namespace toDo1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number you want to make stopping point counting from 1\nbtw this is Method1 :)\n");
            var n1 = int.Parse(Console.ReadLine());

            Console.WriteLine("\nEnter a number you want to make stopping point counting from 1\nand this is Method2 :)" +
                "\n\nP.S. Two method will start at the same time");
            var n2 = int.Parse(Console.ReadLine());

            Thread method1Runner = new(() => Method1(n1));
            method1Runner.Start();

            Thread method2Runner = new(() => Method2(n2));
            method2Runner.Start();
        }

        public static void Method1(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine("\nMethod1 " + i);
                Thread.Sleep(50);
            }
        }

        public static void Method2(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine("\nMethod2 " + i);
                Thread.Sleep(50);
            }
        }

    }
}
