using System;

namespace Task3_3_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите слово:");
            string s = Console.ReadLine();
            Console.WriteLine($"Ваше слово на языке {s.GetLanguage()}.");
        }
    }
}
