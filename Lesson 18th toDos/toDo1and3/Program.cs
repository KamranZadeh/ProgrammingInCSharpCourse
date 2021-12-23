using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System;

namespace toDo1and3 
{
    class Program
    {
        static void Main(string[] args)
        {
            Table table = new();

            // This indexer works. If you enter name that doesn't exits in the list if will throw OutOfRange exception.

            Console.WriteLine(table[3].Name) ;
            Console.WriteLine(table["Ann"].Name);

        }

    }

    public class Guest
    {
        public string Name { get; set; }
    }

    public class Table
    {
        public Table()
        {
            Guests = new List<Guest>()
            {
                new Guest(){Name = "John"},   
                new Guest(){Name = "Charlie"},
                new Guest() {Name = "Jill"},
                new Guest(){Name = "Jane"},
                new Guest(){Name = "Martin"},
                new Guest(){Name = "Ann"},
                new Guest(){Name = "Eve"}
            };
        }

        private List<Guest> Guests { get; set; }

        public Guest this[int index]
        {
            get => Guests[index];
            set => Guests[index] = value;
        }

        public Guest this[string name]
        {
            get
            {
                int i;

                for (i = 0; i < Guests.Count; i++)
                {
                    if (name == Guests[i].Name)
                    {
                        i = i;
                        break;
                    }
                    
                }
                return Guests[i];
            }


        }
    }




}
