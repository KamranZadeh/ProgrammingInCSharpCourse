using System;
using System.IO;
using System.Threading;

namespace Student_Accreditation_App
{
    class Program
    {
        static void Main()
        {

            const string myDb = @"D:\myFolder\documents\StudentFile.doc";
            string answer;

            do
            {
                Student student = new();

                Console.WriteLine("Add a student to data base\n" +
                    "Enter name of the student: ");
                student.Name = Console.ReadLine();

                Console.WriteLine("Enter surname of the student");
                student.Surname = Console.ReadLine();

                Console.WriteLine("Enter age of the student");
                student.Age = int.Parse(Console.ReadLine());


                string content = $"Student name: {student.Name}\n" +
                    $"Student surname: {student.Surname}\n" +
                    $"Student age: {student.Age}\n\n";

                Thread.Sleep(1000);

                File.AppendAllText(myDb, content);


                Console.WriteLine("Do want to add another student? Yes, Cool\\No, Nay");
                answer = Console.ReadLine();


            } while (FromString(answer.ToLower()));

        }

        private enum BooleanAliases
        {
            yes = 1,
            aye = 1,
            cool = 1,
            nay = 0,
            no = 0
        };

        static bool FromString(string str) => Convert.ToBoolean(Enum.Parse(typeof(BooleanAliases), str));
    }
}

