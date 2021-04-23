using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace File_Management_System
{
    class Program
    {
        static void Main(string[] args)
        {
            FileWatcher watcher = new FileWatcher();
            Console.WriteLine("Select the program mode\r\n1.The observer mode\r\n2.Mode for rollback changes\r\n" +
                "To exit the program, click any button");
            int.TryParse(Console.ReadLine(),out int choice);
            switch (choice)
            {
                case 1:
                    watcher.Watch();
                    Console.ReadLine();
                    break;
                case 2:
                    watcher.PrintStroe();
                    int.TryParse(Console.ReadLine(), out int choiceOfRoll); 
                    if (watcher.GetlistOfChanges().ContainsKey(choiceOfRoll)) 
                        watcher.RollBack(choiceOfRoll);
                    break;
                default:
                    return;
            }
        }
    }
}
