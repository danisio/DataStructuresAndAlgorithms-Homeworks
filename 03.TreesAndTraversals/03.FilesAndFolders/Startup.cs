/*Define classes File { string name, int size } and Folder { string name, File[] files, Folder[] childFolders } and using them build a tree keeping all files and folders on the hard drive starting from C:\WINDOWS. Implement a method that calculates the sum of the file sizes in given subtree of the tree and test it accordingly. Use recursive DFS traversal.*/

namespace FilesAndFolders
{
    using System;
    using System.IO;

    public class Startup
    {
        private const string RootPath = @"C:\Windows";
        private static readonly Folder Root = new Folder(RootPath);

        public static void Main()
        {
            TraverseDirDFS(new DirectoryInfo(RootPath), Root);
            Console.WriteLine("Total size is {0} bytes", Root.GetSizeOfAllFiles());
        }

        private static void TraverseDirDFS(DirectoryInfo dir, Folder folder)
        {
            try
            {
                var files = dir.GetFiles();
                foreach (var file in files)
                {
                    var myFile = new File(file.Name, file.Length);

                    folder.Files.Add(myFile);
                }

                var dirs = dir.GetDirectories();
                foreach (var d in dirs)
                {
                    var newFolder = new Folder(d.Name);

                    TraverseDirDFS(d, newFolder);

                    folder.Folders.Add(newFolder);
                }
            }
            catch (UnauthorizedAccessException)
            {
            }
        }
    }
}
