using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace toDo2
{
    class SchoolPerson
    {
        public string SchoolName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public byte CurrentClass { get; set; }
        public DateTime DateOfBirth { get; set; }

        private byte _age;

        public byte Age 
        {
            get { return _age; }
            set
            {
                if (value > 6 && value < 50 )
                {
                    _age = value;
                }
                else
                {
                    throw new Exception("invalid number!");
                }
            }
        }

        public void Greet()
        {
            Console.WriteLine($"Hello {Name} {Surname}");
        }

        public void GoToClasses()
        {
            Console.WriteLine("Inside Base GoToClasses method");
        }
    }
}
