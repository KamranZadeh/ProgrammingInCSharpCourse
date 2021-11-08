using System;

namespace toDo3
{
    class StudentProfessorTest
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            person.Greet();
            Console.WriteLine();

            Student student = new Student();
            student.SetAge(27);
            student.Greet();
            student.ShowAge();
            student.Study();
            Console.WriteLine();

            Teacher teacher = new Teacher();
            teacher.SetAge(29);
            teacher.Greet();
            teacher.Explain();


        }
    }

    public class Person
    {
        public void Greet()
        {
            Console.WriteLine("Hello!");
        }

        public int age;
        public void SetAge(int n)
        {
            age = n;
        }

    }

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

    public class Teacher : Person
    {
        public void Explain()
        {
            Console.WriteLine("I'm explaining");
        }
    }
}
