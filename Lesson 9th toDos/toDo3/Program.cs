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
}
