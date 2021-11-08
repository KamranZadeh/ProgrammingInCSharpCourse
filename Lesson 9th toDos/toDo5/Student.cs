using System;

namespace toDo5
{
    class Student : Person
    {

        public void Study()
        {
            Console.WriteLine("Studying");
        }

        public Student(string name) : base(name)
        {
            
        }

    }
}
