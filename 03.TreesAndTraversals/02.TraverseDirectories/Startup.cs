/*Write a program to traverse the directory C:\WINDOWS and all its subdirectories recursively and to display all files matching the mask *.exe. Use the class System.IO.Directory.*/

namespace TraverseDirectories
{
    using System;
    using System.IO;

    public class Startup
    {
        public static void Main()
        {
            string path = @"C:\Windows";

            Traverse(path);
        }

        private static void Traverse(string path)
        {
            string[] files = Directory.GetFiles(path);
            foreach (var file in files)
            {
                if (file.EndsWith(".exe"))
                {
                    Console.WriteLine(new FileInfo(file).Name);
                }
            }

            try
            {
                string[] dirs = Directory.GetDirectories(path);
                foreach (var dir in dirs)
                {
                    Traverse(dir);
                }
            }
            catch (UnauthorizedAccessException)
            {
            }
        }
    }
}
