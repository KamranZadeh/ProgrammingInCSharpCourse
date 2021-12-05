using System;
using System.Collections.Generic;
using System.Diagnostics;

public class Program
{
    public static void Main2()
    {
        Dictionary<string, bool> characters = new Dictionary<string, bool>()
        {
            { "Luke", true },
            { "Han", false },
            { "Chewbacca", false }
        };

        characters.Remove("Han");
    }

    public static void Main3()
    {
        Dictionary<string, int> people = new Dictionary<string, int>();

        people.Add("Kamran", 27);
        people.Add("Vasif", 28);

        foreach (var key in people.Keys)
        {
            Console.WriteLine($"The first person on the list of people is: " + key);
            break;
        }
    }

    static void Main3()
    {
        List<string> processToKill = new List<string>(3);

        List<string> process = new();

        process.Add("Explorer.exe");
        process.Add("Windows.exe");
        process.Add("Something.exe");


        foreach (var p in process)
        {
            if (p != "Explorer.exe")
            {
                processToKill.Add(p);
            }
        }

        foreach (var p in processToKill)
        {
            Console.WriteLine(p);
        }

        Console.WriteLine(string.Format("Capacity {0}", processToKill.Capacity));
        Console.WriteLine(string.Format("Count {0}", processToKill.Count));
    }
}
