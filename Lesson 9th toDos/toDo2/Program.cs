using System;

namespace toDo2
{
    class Program
    {
        static void Main(string[] args)
        {
            Person[] persons = new Person[3];

            for (int i = 0; i < 3; i++)
            {
                persons[i] = new Person(Console.ReadLine());
            }

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(persons[i].ToString());
            }
        }
    }
}
