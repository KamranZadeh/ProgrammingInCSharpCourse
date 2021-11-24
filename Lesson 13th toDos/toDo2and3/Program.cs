using Amazon.DirectoryService.Model;
using Microsoft.VisualBasic;
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace toDo2and3
{
    class Program
    {
        static void Main()
        {
            GetRamInfo();
            GetCpuInfo();
        }
        
        public static void GetRamInfo()
        {
            var searcher = new ManagementObjectSearcher(new ObjectQuery("SELECT * FROM Win32_OperatingSystem"));
            var results = searcher.Get();

            foreach (var result in results)
            {
                var total = result["TotalVisibleMemorySize"]; // find total space
                var free = result["FreePhysicalMemory"]; // find free space
                var t = Convert.ToInt32(total) / 1024f; // convert byte to Mb
                var f = Convert.ToInt32(free) / 1024f; // convert byte to Mb
                Console.WriteLine($"Total RAM size is {Math.Round(t)} MB ");
                Console.WriteLine($"Using RAM memory is {Math.Round(t-f)} MB");
            }

        }

        public static void GetCpuInfo()
        {
            PerformanceCounter cpu = new("Processor", "% Processor Time", "_Total");
            cpu.NextValue();
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine($"Current CPU usage is {Math.Round(cpu.NextValue())}%");
        }
    }
    
}
