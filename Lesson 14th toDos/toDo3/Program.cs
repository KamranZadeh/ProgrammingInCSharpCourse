using System;
using System.Collections;
using System.Linq;

namespace toDo3
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "Kamran";

            try
            {
                Convert.ToDouble(name);
            }
            catch(FormatException exc)
            {
                Console.WriteLine(exc.Message);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
            finally
            {
                Console.WriteLine("Program ended");
            }

        }
    }
}
