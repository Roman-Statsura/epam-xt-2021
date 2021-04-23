using System;
using System.Collections.Generic;
using System.IO;

namespace File_Management_System
{
    public class FileWatcher
    {
        private readonly string pathToFolder = @"C:\myFile";
        private readonly string storePath = @"C:\store";
        private readonly Dictionary<int, string> listOfChanges = new Dictionary<int, string>();

        public FileWatcher()
        {
            AddStoreToList();
        }
        public Dictionary<int,string> GetlistOfChanges() => listOfChanges;
        public void Watch()
        {
            using var watcher = new FileSystemWatcher(pathToFolder)
            {
                NotifyFilter = NotifyFilters.Attributes
                                 | NotifyFilters.CreationTime
                                 | NotifyFilters.DirectoryName
                                 | NotifyFilters.FileName
                                 | NotifyFilters.LastAccess
                                 | NotifyFilters.LastWrite
                                 | NotifyFilters.Security
                                 | NotifyFilters.Size
            };

            watcher.Changed += OnChanged;
            watcher.Created += OnChanged;
            watcher.Deleted += OnChanged;
            watcher.Renamed += OnChanged;

            watcher.Filter = "*.*";
            watcher.IncludeSubdirectories = true;
            watcher.EnableRaisingEvents = true;

            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            string path = storePath + "\\" + DateTime.Now.ToString("Дата dd-MM-yy Время hh-mm-ss");
            Directory.CreateDirectory(path);

            Console.WriteLine($"Changed: {e.FullPath}");
            CopyFiles(pathToFolder, path);
        }
        private static void CopyFiles(string sourcePath, string targetPath)
        {
            foreach (string dirPath in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
            {
                Directory.CreateDirectory(dirPath.Replace(sourcePath, targetPath));
            }
            foreach (string newPath in Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories))
            {
                File.Copy(newPath, newPath.Replace(sourcePath, targetPath), true);
            }
        }
        private void DeleteAllContent(string path)
        {
            DirectoryInfo info = new DirectoryInfo(path);
            foreach (FileInfo file in info.GetFiles())
                file.Delete();
        }
        public void RollBack(int v)
        {
            DeleteAllContent(pathToFolder);
            string path = listOfChanges[v];
            CopyFiles(path, pathToFolder);
            Console.WriteLine(Environment.NewLine + "RollBack happened successfully!");
        }
        private void AddStoreToList()
        {
            string[] dirs = Directory.GetDirectories(storePath);
            for (int i = 1; i < dirs.Length+1; i++)
            {
                listOfChanges.Add(i, dirs[i - 1]);
            }
        }
        public void PrintStroe()
        {
            foreach (var item in listOfChanges)
            {
                Console.WriteLine(item.Key + " : " + item.Value[item.Value.LastIndexOf(@"Дата")..]);
            }
        }
    }
}
