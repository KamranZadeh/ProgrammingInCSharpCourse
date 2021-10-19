using System;

namespace Lesson_4_toDos
{
    class Program
    {
        static void Main1(string[] args)
        {
            
            DateTime myBirtday = new DateTime(1994, 9, 14, 0, 0, 0);

            Console.WriteLine(myBirtday.DayOfWeek);

        }

        static void Main2(string[] args)
        {

            var myBirtday = new DateTime(1994, 9, 14);
            var myDayAge = DateTime.Now - myBirtday;

            Console.WriteLine(myDayAge.Days);

        }

        static void Main3(string[] args)
        {

            DateTime qirxMerasimi = DateTime.Now.AddDays(40);

            Console.WriteLine(qirxMerasimi.DayOfWeek);

        }

        static void Main4(string[] args)
        {
            Console.Write("Enter day number(from 1 to 31): ");
            int day = int.Parse(Console.ReadLine());

            Console.Write("Enter month number(from 1 to 12): ");
            int month = int.Parse(Console.ReadLine());
            
            Console.Write("Enter a year(4 digits): ");
            int year = int.Parse(Console.ReadLine());

            DateTime inputtedDate = new DateTime(year, month , day);
            string formattedDate = inputtedDate.ToString("dd/MM/yyyy");

            DateTime now = DateTime.Now;
            string formattedNow = now.ToString("dd/MM/yyyy");

            bool b = formattedDate == formattedNow;

            Console.WriteLine("The formatted date is: " + formattedDate);
            Console.WriteLine("The current date status is: " + b);

        }
        static void Main5(string[] args)
        {
            Console.Write("Enter day number(from 1 to 31): ");
            int day = int.Parse(Console.ReadLine());

            Console.Write("Enter month number(from 1 to 12): ");
            int month = int.Parse(Console.ReadLine());

            Console.Write("Enter a year(4 digits): ");
            int year = int.Parse(Console.ReadLine());

            DateTime inputtedDate = new DateTime(year, month, day);
            string formattedDate = inputtedDate.ToString("dd/MM/yyyy");

            Console.WriteLine(formattedDate);
            Console.WriteLine("31/12/" + year);
        }

        

        static void Main6(string[] args)
        {
            Console.Write("Enter day number(from 1 to 31): ");
            int day = int.Parse(Console.ReadLine());

            Console.Write("Enter month number(from 1 to 12): ");
            int month = int.Parse(Console.ReadLine());

            Console.Write("Enter a year(4 digits): ");
            int year = int.Parse(Console.ReadLine());

            DateTime inputtedDate = new DateTime(year, month, day);
            string formattedDate = inputtedDate.ToString("dd/MM/yyyy");

            DayOfWeek dayOfWeek = inputtedDate.DayOfWeek;

            Console.WriteLine("The formatted Date is: " + formattedDate);

            switch (dayOfWeek)
            {
                case DayOfWeek.Monday:
                    Console.WriteLine("The last day of the week for the above date is: " + inputtedDate.AddDays(6).ToString("dd/MM/yyyy"));
                    break;
                case DayOfWeek.Tuesday:
                    Console.WriteLine("The last day of the week for the above date is: " + inputtedDate.AddDays(5).ToString("dd/MM/yyyy"));
                    break;
                case DayOfWeek.Wednesday:
                    Console.WriteLine("The last day of the week for the above date is: " + inputtedDate.AddDays(4).ToString("dd/MM/yyyy"));
                    break;
                case DayOfWeek.Thursday:
                    Console.WriteLine("The last day of the week for the above date is: " + inputtedDate.AddDays(3).ToString("dd/MM/yyyy"));
                    break;
                case DayOfWeek.Friday:
                    Console.WriteLine("The last day of the week for the above date is: " + inputtedDate.AddDays(2).ToString("dd/MM/yyyy"));
                    break;
                case DayOfWeek.Saturday:
                    Console.WriteLine("The last day of the week for the above date is: " + inputtedDate.AddDays(1).ToString("dd/MM/yyyy"));
                    break;
                    
                default:
                    Console.WriteLine("Inputted day is the last day of the week.");
                    break;
            }

            
        }

        static void Main7(string[] args)
        {
            Console.WriteLine("Enter 1st number: ");
            int num1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter 2nd number: ");
            int num2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter 3rd number: ");
            int num3 = int.Parse(Console.ReadLine());

            if (num1 >= num2 && num1 >= num3)
            {
                Console.WriteLine("The 1st number is the greatest among three");
            }
            else if (num2 >= num1 && num2 >= num3)
            {
                Console.WriteLine("The 2nd number is the greatest among three");
            }
            else
            {
                Console.WriteLine("The 3rd number is the greatest among three");
            }
        }

        static void Main8(string[] args)
        {
            Console.WriteLine("Enter a day number of week to know which day it is: ");
            int day = int.Parse(Console.ReadLine());

            switch (day)
            {
                case 1:
                    Console.WriteLine("Monday");
                    break;
                case 2:
                    Console.WriteLine("Tuesday");
                    break;
                case 3:
                    Console.WriteLine("Wednesday");
                    break;
                case 4:
                    Console.WriteLine("Thursday");
                    break;
                case 5:
                    Console.WriteLine("Friday");
                    break;
                case 6:
                    Console.WriteLine("Saturday");
                    break;
                case 7:
                    Console.WriteLine("Sunday");
                    break;

                default:
                    Console.WriteLine("Invalid Number!");
                    break;
            }
        }

        static void Main9(string[] args)
        {
            Console.WriteLine("Enter 1st number: ");
            double num1 = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter 2nd number: ");
            double num2 = double.Parse(Console.ReadLine());

            Console.WriteLine("Choose your option with these numbers: ");
            Console.WriteLine("1-Addition");
            Console.WriteLine("2-Substraction");
            Console.WriteLine("3-Multiplication");
            Console.WriteLine("4-Division");
            Console.WriteLine("5-Exit");

            byte operation = byte.Parse(Console.ReadLine());

            switch (operation)
            {
                case 1:
                    Console.WriteLine(num1 + num2);
                    break;
                case 2:
                    Console.WriteLine(num1 - num2);
                    break;
                case 3:
                    Console.WriteLine(num1 * num2);
                    break;
                case 4:
                    Console.WriteLine(num1 / num2);
                    break;
                case 5:
                    break;
                default:
                    break;
            }
        }

    }
}
