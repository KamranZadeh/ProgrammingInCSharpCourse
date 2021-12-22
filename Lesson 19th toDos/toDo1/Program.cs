using System;
using System.Threading;

namespace toDo1
{
    class Program
    {
        static void Main(string[] args)
        {

            Thread method1Runner = new(Method1);
            method1Runner.Start();

            Thread method2Runner = new(Method2);
            method2Runner.Start();

        }

        public static int helper = 0;

        public static void Method1()
        {
            Console.WriteLine("Enter a number you want to make stopping point counting from 1\nbtw this is Method1 :)\n");
            var n = int.Parse(Console.ReadLine());

            while (true)
            {
                if (helper == 0)
                {
                    Thread.Sleep(200);
                }
                else
                {
                    break;
                }
            }

            

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine("\nMethod1 " + i);
                Thread.Sleep(50);
            }
        }

        public static void Method2()
        {
            Console.WriteLine("Enter a number you want to make stopping point counting from 1\nand this is Method2 :)" +
                "\n\nP.S. Two method will start at the same time");
            var n = int.Parse(Console.ReadLine());

            if (n != null)
            {
                helper++;
            }

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine("\nMethod2 " + i);
                Thread.Sleep(50);
            }
        }

    }
}
