using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System;
using System.Linq;

namespace task1
{
    class Program
    {
        static void Main()
        {

            Person person1 = new()
            {
                Id = 1,
                Name = "Shahali",
                Surname = "Shahaliyev"
            };

            Person person2 = new()
            {
                Id = 2,
                Name = "Xanali",
                Surname = "Shahaliyev",
                Parent = person1
            };

            Person person3 = new()
            {
                Id = 3,
                Name = "Shixali",
                Surname = "Shahaliyev",
                Parent = person2
            };

            Person person4 = new()
            {
                Id = 4,
                Name = "Tapdig",
                Surname = "Shahaliyev",
                Parent = person2
            };

            Person person5 = new()
            {
                Id = 5,
                Name = "Rafiq",
                Surname = "Shahaliyev",
                Parent = person3
            };

            Person person6 = new()
            {
                Id = 6,
                Name = "Vahid",
                Surname = "Shahaliyev",
                Parent = person3
            };

            Person person7 = new()
            {
                Id = 7,
                Name = "Ramin",
                Surname = "Shixaliyev",
                Parent = person6
            };

            Person person8 = new()
            {
                Id = 8,
                Name = "Ferid",
                Surname = "Shixaliyev",
                Parent = person5
            };

            Person person9 = new()
            {
                Id = 9,
                Name = "Onur",
                Surname = "Shixaliyev",
                Parent = person7
            };

            person1.Children.Add(person2);
            person2.Children.Add(person3);
            person2.Children.Add(person4);
            person3.Children.Add(person5);
            person3.Children.Add(person6);
            person5.Children.Add(person8);
            person6.Children.Add(person7);
            person7.Children.Add(person9);

            List<Person> personsList = new();
            personsList.Add(person1);
            personsList.Add(person2);
            personsList.Add(person3);
            personsList.Add(person4);
            personsList.Add(person5);
            personsList.Add(person6);
            personsList.Add(person7);
            personsList.Add(person8);
            personsList.Add(person9);

            Console.WriteLine("We have 9 people added with parent-child relationship.\n\n" +
                "***ENTER ID(1 to 9)*** to know who is grandparent of that person and\n" +
                "Who are the 4rd generation of childs of this person");
            int n = int.Parse(Console.ReadLine());

            foreach (var person in personsList)
            {
                if (person.Id == n)
                {
                    if (person.Parent != null && person.Parent.Parent != null)
                    {
                        Console.WriteLine($"The grandparent of the person {person.Name} is {person.Parent.Parent.Name}");
                    }
                    else
                    {
                        continue;
                    }
                    

                    if (person.Children.Count != 0)
                    {
                        foreach (var child in person.Children)
                        {
                            if (child.Children.Count != 0)
                            {
                                foreach (var grandChild in child.Children)
                                {
                                    if (grandChild.Children.Count != 0)
                                    {
                                        foreach (var grandGrandChild in grandChild.Children)
                                        {
                                            Console.WriteLine($"The 4rd generation child of the person {person.Name} is {grandGrandChild.Name}");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

            }

        }

        public class Person
        {

            public int Id { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public DateTime BirthDate { get; set; }

            public List<Person> Children = new List<Person>();

            public Person Parent { get; set; }
        }
    }
}
