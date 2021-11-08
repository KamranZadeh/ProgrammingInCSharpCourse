using System;

namespace toDo3
{
    public class Student : Person
    {
        public void Study()
        {
            Console.WriteLine("I'm studying");
        }

        public void ShowAge()
        {
            Console.WriteLine($"I'm {age} years old");
        }

    }
}
