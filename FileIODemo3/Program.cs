using System;
using System.IO;

namespace FileIODemo3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }
        private static void GetAllFiles()
        {
            string[] files = Directory.GetFiles("C:\\Python310\\Tools\\scripts");
            foreach (string file in files)
            {
                Console.WriteLine(file);
            }
        }
        private static void GetAllDrives()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                Console.WriteLine(drive.Name + "\t" + drive.TotalSize + "\t" + drive.TotalFreeSpace);
            }
        }
    }
}
