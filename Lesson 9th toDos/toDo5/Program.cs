using System;

namespace toDo5
{
    class Program
    {
        static void Main(string[] args)
        {

            Person[] person = new Person[3];


            for (int i = 0; i < 3; i++)
            {
                if (i==0)
                {
                    person[i] = new Teacher(Console.ReadLine());
                }
                else
                {
                    person[i] = new Student(Console.ReadLine());
                }
            }

            

            for (int i = 0; i < 3; i++)
            {
                if (i==0)
                {
                    ((Teacher)person[i]).Explain();
                }
                else
                {
                    ((Student)person[i]).Study();
                }
            }
        }
    }
}
