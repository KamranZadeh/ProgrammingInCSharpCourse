using System;

namespace toDo1
{
    class Program
    {
        static void Main()
        {
            Shape[] shapes = new Shape[4];


            shapes[0] = new Rectangle(5, 6);
            shapes[1] = new Circle(5);
            shapes[2] = new Rectangle(15, 20);
            shapes[3] = new Circle(50.2);

            foreach (var item in shapes)
            {
                Console.WriteLine("The area of the shape is: " + item.Area());
                Console.WriteLine("The perimeter of the shape is: " + item.Perimeter());
                Console.WriteLine();
            }

        }
    }
}
