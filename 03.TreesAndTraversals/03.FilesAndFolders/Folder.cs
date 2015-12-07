namespace FilesAndFolders
{
    using System.Collections.Generic;
    using System.Linq;

    public class Folder
    {
        public Folder(string name)
        {
            this.Name = name;
            this.Files = new List<File>();
            this.Folders = new List<Folder>();
        }

        public string Name { get; set; }

        public List<File> Files { get; set; }

        public List<Folder> Folders { get; set; }

        public long GetSizeOfAllFiles()
        {
            return this.Files.Sum(f => f.Size) + this.Folders.Sum(f => f.GetSizeOfAllFiles());
        }
    }
}
