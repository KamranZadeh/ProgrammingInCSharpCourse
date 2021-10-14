using System;

namespace Lesson_3rd_toDos
{
    class Program
    {
        static void Main1(string[] args)
        {
            Console.Write("Enter a number to know number is even or odd: ");

            int num;

            while (true)
            {
                try
                {
                    num = int.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {

                    Console.WriteLine("You should add a number! Try again!");
                }
            }

            if (num % 2 == 0)
            {
                Console.WriteLine("The number you added is even");
            }
            else
            {
                Console.WriteLine("The number you added is odd");
            }
        }

        static void Main2(string[] args)
        {
            Console.Write("Enter 2 words and check if first word contains the second: ");
            string input1 = Console.ReadLine();
            string input2 = Console.ReadLine();

            bool b = input1.Contains(input2);
            Console.WriteLine(b);
        }

        static void Main3(string[] args)
        {
            Console.WriteLine("Enter 2 numbers to calculate exact value of those: ");
            
            double a;

            while (true)
            {
                try
                {
                    a = double.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {

                    Console.WriteLine("You should add a number! Try again!");
                }
            }

            double b;

            while (true)
            {
                try
                {
                    b = double.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {

                    Console.WriteLine("You should add a number! Try again!");
                }

            }


                    Console.WriteLine(a / b);

                }

            }

        }



