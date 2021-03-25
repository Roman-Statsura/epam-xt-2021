using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Task3_1_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "After a recent move To my home, I realized the scale of the 'tragedy' with unread books." +
                " Nothing else fits into my cart with unread, which means that I have to tie up (temporarily) " +
                "shopping and read what I have.";
            Dictionary<string, int> QuantityOfRepeatitions = new Dictionary<string, int>();
            string[] mass = Regex.Replace(s, "[-.?!)(,:']", "").ToLower().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int normal = (int)Math.Round(mass.Length * 0.1);
            Console.WriteLine(normal);
            foreach (var item in mass)
            {
                if (QuantityOfRepeatitions.ContainsKey(item)) QuantityOfRepeatitions[item]++;
                else QuantityOfRepeatitions.Add(item, 1);
            }
            if (CheckMonotonousText(QuantityOfRepeatitions, normal)) Console.WriteLine("К сожалению, Ваша речь однообразна(");
            else Console.WriteLine("Поздравляем! Ваша речь разнообразна!");
            foreach (var item in QuantityOfRepeatitions) Console.WriteLine($"{item.Key} : {item.Value}");
        }
        public static bool CheckMonotonousText(Dictionary<string, int> d,int norm)
        {
            foreach (var item in d) 
                if (item.Value >= norm) return true;
            return false;
        }
    }
}
