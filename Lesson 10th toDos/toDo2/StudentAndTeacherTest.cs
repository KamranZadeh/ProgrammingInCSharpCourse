using System;

namespace toDo2
{
    class StudentAndTeacherTest
    {
        static void Main()
        {
            SchoolPerson schoolPerson = new SchoolPerson();
            schoolPerson.Greet();
            Console.WriteLine("____________");

            Student student = new Student();
            student.Age = 21;
            student.Greet();
            student.ShowAge();
            student.GoToClasses();
            Console.WriteLine("____________");

            Teacher teacher = new Teacher();
            teacher.Age = 30;
            teacher.Greet();
            teacher.GoToClasses();
            teacher.Explain();
        }
    }
}
