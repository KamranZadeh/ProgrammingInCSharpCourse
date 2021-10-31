using System;
using System.Linq;
using System.Threading;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;

namespace Lesson_6th_toDos
{
    class Program
    {

        static void Main123(string[] args)
        {

            /* Enter the value between 10 and 100.Initialize int array with random values with length of user entered value.Do following tasks

            1. Write a program in C# sort array both descending and ascending order
            2. Write a C# program to find the 3rd max element of array.
            3. Write a program in C# to find first 4 max elements.

                I PLACED 3 OF THE PROGRAMS IN 1 MAIN METHOD.*/

            Random rnd = new();

            Console.WriteLine("Enter lenthg of random numbers(1 to 100): ");
            int n = int.Parse(Console.ReadLine());

            int[] randomNums = new int[n];

            for (int i = 0; i < n; i++)
            {
                randomNums[i] = rnd.Next(1, 101);
            }

            Console.WriteLine("Sorted in ascending order of random numbers\n");

            Array.Sort(randomNums);

            foreach (int i in randomNums)
            {
                Console.WriteLine(i);
            }

            Console.Write("\n\nSorted in descending order of random numbers\n\n");

            Array.Reverse(randomNums);

            foreach (int j in randomNums)
            {
                Console.WriteLine(j);
            }

            Console.WriteLine("\nThe 3rd max element of array is " + randomNums[2] + "\n\n");

            Console.WriteLine("The first 4 max elements of array is: \n");

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine(randomNums[i]);
            }


        }

        static void Main4()
        {
            /*Write a program in C# to create a function to swap the values of two integer numbers without additional variable. 
            Test Data : Enter a number: 5 Enter another number: 6 Expected Output : Now the 1st number is : 6 , and the 2nd number is : 5*/

            Console.WriteLine("Enter first number: ");
            int x = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter second number: ");
            int y = int.Parse(Console.ReadLine());

            ReverseInputtedNums4(x, y);
        }

        public static void ReverseInputtedNums4(int x, int y)
        {
            Console.WriteLine("Now the first number is " + y);
            Console.WriteLine("And the second number is " + x);
        }

        static void Main5()
        {
            /*Write a program in C# to create a function to display the n number Fibonacci sequence. 
            Test Data : Input number of Fibonacci Series : 5 
            Expected Output : The Fibonacci series of 5 numbers is : 0 1 1 2 3 5 8*/

            Console.WriteLine("Enter n number to get n series of Fibonacci numbers: ");

            int num = int.Parse(Console.ReadLine());
            GetFibonnaciRow5(num);
        }

        static void GetFibonnaciRow5(int num)
        {

            int n1 = 0;
            int n2 = 1;
            int n3;
            Console.Write("0 1 ");

            for (int i = 0; i < num; i++)
            {
                n3 = n1 + n2;
                n1 = n2;
                n2 = n3;
                Console.Write(n3 + " ");
            }
        }    
                
        static void Main6()
        {

            /* Write a program in C# to create a function to calculate the sum of the individual digits of a given number. 
            Test Data : Enter a number: 1234 Expected Output : The sum of the digits of the number 1234 is : 10 */

            Console.WriteLine("This program will calculate the sum of the individual digits of a given number.\nEnter your number: ");

            int num = int.Parse(Console.ReadLine());
            SumDigitsOfGivenNum6(num);

        }

        static void SumDigitsOfGivenNum6(int num)
        {
            var numString = num.ToString();

            char[] numArray = numString.ToCharArray();

            int numDigit;
            int sum = 0;

            for (int i = 0; i < numArray.Length; i++)
            {
                numDigit = numArray[i] - '0';
                sum += numDigit;
            }

            Console.WriteLine(sum);
        }

        static void Main7()
        {
            /*Write a program in C# Sharp to create a function to input a string and count number of spaces are in the string. 
            Test Data : Please input a string : This is a test string. Expected Output : "This is a test string." contains 4 spaces*/

            Console.WriteLine("Enter your sentence the program will tell you how many spaces contain in the sentence: ");

            var testString = Console.ReadLine();
            HowManySpacesContainInSentence7(testString);

        }

        static void HowManySpacesContainInSentence7(string testString)
        {
            
            char[] testArray = testString.ToCharArray();

            int counter = 0;

            for(int i=0; i<testArray.Length; i++)
            {
                if (testArray[i] == ' ')
                {
                    counter++;
                }
            }

            Console.WriteLine("Count of spaces is " + counter);
        }

        static void Main()
        {
            int n=5;
            string space = "";

            for (int i = 0; i < n; i++)
            {
                

                for (int j = 0; j < j-n; j--)
                {
                    
                    space = space + " ";
                }

                for (int k = 0; k < 2*n-1; k++)
                {
                    space = space + "#";
                    Console.WriteLine(space);
                }

                
            }

        }

        static string catAndMouse(int x, int y, int z)
        {
            int catA = z - x;
            int catB = z - y;

            string resultA, resultB, resultC;

            if (catA<0)
            {
                catA = -1 * catA;
            }
            if(catB<0)
            {
                catB = -1 * catB;
            }

            if (catA<catB)
            {
                resultA = "Cat A";
                return resultA;
            }
            else if (catA>catB)
            {
                resultB = "Cat B";
                return resultB;
            }
            else
            {
                resultC = "Mause C";
                return resultC;
            }

        }

    }
}
