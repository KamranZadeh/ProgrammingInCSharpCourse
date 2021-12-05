using System;

namespace toDo4
{
    class Program
    {

        static void Main()
        {

            while (true)
            {
                try
                {
                    int n = int.Parse(Console.ReadLine());
                    if (isNumberEven(n))
                    {
                        Console.WriteLine(n + " is even number");
                        break;
                    }

                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.Message +
                        "\nYou should enter a even number");
                }
            }
        }

        static bool isNumberEven(int n)
        {
            if (n % 2 == 0)
            {
                return true;
            }
            else
            {
                throw new Exception("Number you entered is not even");
            }
        }
    }
}
