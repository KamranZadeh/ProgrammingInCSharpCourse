using System;
using System.IO;

namespace toDo1
{
    class Program
    {
        static void Main()
        {
            byte driveCount = 0;

            foreach (var drive in DriveInfo.GetDrives())
            {
                driveCount++;
            }

            Console.WriteLine($"This computer has {driveCount} drives\n");

            foreach (var drive in DriveInfo.GetDrives())
            {

                Console.WriteLine($"The {drive.Name} drive has {drive.TotalSize/(1024*1024)} MB total size\n" +
                    $"{drive.AvailableFreeSpace/(1024*1024)} MB aviable free space.\n" +
                    $"And {(drive.TotalSize-drive.AvailableFreeSpace)/(1024*1024)} MB is in use\n");

            }
        }
    }
}
