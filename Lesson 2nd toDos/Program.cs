using System;

namespace Lesson_2nd_toDos
{
    class Program
    {
        static void Main1(string[] args)
        {
            Console.Write("Enter tree letters one by one: ");


            char c1;


            while (true)
            {
                try
                {
                    c1 = char.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {

                    Console.WriteLine("You should only add a character. Try again!");
                }
            }

            var input1 = c1.ToString();

            char c2;

            Console.WriteLine("Enter another letter: ");

            while (true)
            {
                try
                {
                    c2 = char.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {

                    Console.WriteLine("You should only add a character. Try again!");
                }
            }

            var input2 = c2.ToString();

            Console.WriteLine("Just a letter to go: ");

            char c3;

            while (true)
            {
                try
                {
                    c3 = char.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {

                    Console.WriteLine("You should only add a character. Try again!");
                }
            }

            var input3 = c3.ToString();



            Console.WriteLine("You got these tree letters in reverse: ");
            Console.WriteLine(input3 + input2 + input1);
        }

      

        static void Main2(string[] args)
        {
            Console.WriteLine("Please, enter your name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Please, enter your surname: ");
            string surname = Console.ReadLine();



            Console.WriteLine(name.ToUpper() + " " + surname.ToUpper());
            Console.ReadLine();
        }

        static void Main3(string[] args)
        {

            Console.Write("Enter radius of a circle to calculate perimeter and area of the circle: ");

            int var1;

            while (true)
            {
                try
                {
                    var1 = Convert.ToInt16(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {

                    Console.WriteLine("You should enter a number: "); ;
                }
            }



            double var2 = Math.Pow(var1, 2);

            double var3 = 2 * 3.14 * var1;
            string per = var3.ToString();

            double var4 = 3.14 * var2;
            string area = var4.ToString();


            Console.WriteLine("The perimeter of the circle is: " + per + "cm.");
            Console.WriteLine("The area of the circle is: " + area + "cm²");
        }
    }
}
