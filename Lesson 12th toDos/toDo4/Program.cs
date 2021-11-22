using System;

namespace toDo4
{
    class Program
    {
        static void Main()
        {
            Car car = new();
            int gasoline = int.Parse(Console.ReadLine());

            if (car.Refuel(gasoline))
            {
                car.Drive();
            }
            else
            {
                Console.WriteLine("Car stopped");
            }
        }

        public class Car : IVehicle
        {
            public bool Refuel(int gasoline)
            {
                if (gasoline<=0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

            public void Drive()
            {
                Console.WriteLine("Driving...");
            }
        }

        interface IVehicle
        {
            void Drive();
            bool Refuel(int gasoline);
        }
    }
}
