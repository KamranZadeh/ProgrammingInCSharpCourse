using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Null_Reference_Exception
{
    class Program
    {
        static void Main1()
        {
            string[] list = new string[5];
            list[0] = "Sunday";
            list[1] = "Monday";
            list[2] = "Tuesday";
            list[3] = "Wednesday";
            list[4] = "Thursday";

            try
            {
                for (int i = 0; i <= 5; i++)
                {
                    Console.WriteLine(list[i].ToString());
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        static void Main2()
        {
            int num1, num2;
            byte result;

            try
            {
                num1 = 30;
                num2 = 60;
                result = Convert.ToByte(num1 * num2);
                Console.WriteLine("{0} x {1} = {2}", num1, num2, result);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

