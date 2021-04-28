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
        public FileSystemWatcher watcher;

        public FileWatcher()
        {
            watcher = new FileSystemWatcher(pathToFolder);
            AddStoreToList();
        }
        public Dictionary<int,string> GetlistOfChanges() => listOfChanges;
        public void Watch()
        {
            watcher.NotifyFilter = NotifyFilters.CreationTime
                                 | NotifyFilters.DirectoryName
                                 | NotifyFilters.FileName
                                 | NotifyFilters.LastWrite;

            watcher.Changed += OnChanged;
            watcher.Created += OnChanged;
            watcher.Deleted += OnChanged;
            watcher.Renamed += OnChanged;

            watcher.IncludeSubdirectories = true;
            watcher.EnableRaisingEvents = true;
            watcher.Filter = "*.*";
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            string path = storePath + "\\" + DateTime.Now.ToString("Дата dd-MM-yy Время hh-mm-ss");
            Directory.CreateDirectory(path);

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
            info.Delete(true);
            Directory.CreateDirectory(path);
        }
        public void RollBack(int v)
        {
            DeleteAllContent(pathToFolder);
            string path = listOfChanges[v];
            CopyFiles(path, pathToFolder);
        }
        private void AddStoreToList()
        {
            string[] dirs = Directory.GetDirectories(storePath);
            for (int i = 1; i < dirs.Length+1; i++)
            {
                listOfChanges.Add(i, dirs[i - 1]);
            }
        }
    }
}
