using System;

namespace toDo5
{
    class Teacher : Person
    {

        public void Explain()
        {
            Console.WriteLine("Explaining");
        }

        public Teacher(string name) : base(name)
        {
            
        }
    }
}
