using System;

namespace Lesson_5th_toDos
{
    class Program
    {
        static void Main1(string[] args)
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(i);
            }
        }

        static void Main2()
        {

            int sum = 0;

            for (int i = 1; i < 20; i += 2)
            {
                sum = sum + i;
            }

            Console.WriteLine(sum);

        }

        static void Main3()
        {
            Console.WriteLine("Enter 3 numbers one by one: ");
            int[] inputNums = new int[] { int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()) };
            int sum = 0;

            for (int i = 0; i < inputNums.Length; i++)
            {
                sum += inputNums[i];
            }

            Console.WriteLine("The sum of the entered numbers is: " + sum);
            Console.WriteLine("Avarage of entered numbers is: " + (sum / inputNums.Length));
        }

        static void Main4()
        {

            int num = int.Parse(Console.ReadLine());

            Console.WriteLine("Multiplication table from 1 to {0}", num);

            for (int j = 1; j <= num; j++)
            {
                Console.WriteLine("Multiplication table of {0}:", j);

                for (int i = 1; i <= 10; i++)
                {
                    Console.WriteLine("{0}x{1} = {2}", j, i, (i * j));
                }

            }


        }



        static void Main5()
        {
            string asterisk = "*";
            string asterisk2 = "*";

            for (int i = 0; i < 15; i++)
            {

                Console.WriteLine(asterisk);
                asterisk = asterisk2 + asterisk;

            }

        }

        static void Main6()
        {
            /* Write a program in C# to make such a pattern like right angle triangle with number 
             * increased by 1. The pattern like :
            1
            2 3
            4 5 6
            7 8 9 10 */

            int num = 1;

            for (int i = 1; i < 10; i++)
            {
                
                for (int j = 0; j < i; j++)
                {
                    Console.Write("{0} ", num++);
                }

                Console.Write("\n");

            }
        }

        static void Main7()
        {
            /* Write a program in C# to display the sum of the series [ 9 + 99 + 999 + 9999 ...]. Test Data :
                Input the number or terms :5
                Expected Output :
                9 99 999 9999 99999
                The sum of the series = 111105 */

            Console.WriteLine("You can display series of 9 by this program and sum them \nEnter row of 9 you want: ");

            int increasedNum = 9;
            int sum = 0;
            int row = int.Parse(Console.ReadLine());

            for (int i = 0; i < row; i++)
            {
                
                Console.WriteLine(increasedNum);
                sum += increasedNum;
                increasedNum = increasedNum * 10 + 9;
                
            }
           
            Console.WriteLine(sum);

        }

        static void Main8()
        {
            /* Write a C# program to find prime numbers up to users entered value.
               Exmpl: input-100, Result: 2, 3, 5, 7, 11, 13 ... 89, 97 */

            int count = int.Parse(Console.ReadLine());

            for (int i = 2; i <= count; i++)
            {
                bool isPrime = true;

                for (int j = 2; j < i; j++)
                {
                    if (i%j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime)
                {
                    Console.WriteLine(i);
                }

            }


        }

        static void Main()
        {
            /* Write a program in C# to check whether a number can be express as sum of two prime numbers.
            Test Data :
            Input a positive integer: 16
            Expected Output :
            16 = 3 + 13
            16 = 5 + 11 */

            Console.WriteLine("?????????????????????????????????????????????????????????\n");


           


        }

        static int CheckNumIsPrime(int num)
        {
            num = int.Parse(Console.ReadLine());
            int counter = 0;

            for (int i = 2; i < num; i++)
            {
                if (num % i == 0)
                {
                    counter++;
                }
            }

            if (counter == 0 && num > 1)
            {
                return num;
            }
            else
            {
                return 0;
            }
        }




        static void Main10()
        {
            /* Write a program in C# to check whether a number is a palindrome (visual simmetric) or not. Test Data :
            Input a number: 121
            Expected Output :
            121 is a palindrome number. */

            int n = int.Parse(Console.ReadLine());
            string numN = Convert.ToString(n);

            char[] cArray = numN.ToCharArray();
            string reverse = "";
            
            for (int i = cArray.Length - 1; i > -1; i--)
            {
                reverse += cArray[i];
            }

            if (numN==reverse)
            {
                Console.WriteLine("{0} is a palindrome number.", numN);
            }
            else
            {
                Console.WriteLine("{0} is NOT a palindrome number.", numN);
            }


        }

    }
}

