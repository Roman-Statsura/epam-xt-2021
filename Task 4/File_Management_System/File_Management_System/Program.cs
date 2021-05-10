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
            Console.WriteLine("Select the program mode\r\n"+
                "1.The observer mode\r\n"+
                "2.Mode for rollback changes\r\n" +
                "To exit the program, click any button");
            int.TryParse(Console.ReadLine(),out int choice);
            switch (choice)
            {
                case 1:
                    watcher.Watch();
                    Console.ReadLine();
                    break;
                case 2:
                    PrintStore(watcher.GetlistOfChanges());
                    int.TryParse(Console.ReadLine(), out int choiceOfRoll);
                    if (watcher.GetlistOfChanges().ContainsKey(choiceOfRoll))
                    {
                        watcher.RollBack(choiceOfRoll);
                        Console.WriteLine(Environment.NewLine + "RollBack happened successfully!");
                    }
                    break;
                default:
                    return;
            }
        }
        public static void PrintStore(Dictionary<int, string> listOfChanges)
        {
            foreach (var item in listOfChanges)
                Console.WriteLine(item.Key + " : " + item.Value[item.Value.LastIndexOf(@"Дата")..]);
        }
    }
}
