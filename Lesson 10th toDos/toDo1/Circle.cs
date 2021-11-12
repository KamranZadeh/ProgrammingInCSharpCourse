namespace toDo1
{
    class Circle : Shape
    {
        public double radius;

        public Circle(double radius)
        {
            this.radius = radius;
        }

        public override double Area()
        {
            return 3.14*radius*radius;
        }

        public override double Perimeter()
        {
            return 2*3.14*radius;
        }
    }
}
