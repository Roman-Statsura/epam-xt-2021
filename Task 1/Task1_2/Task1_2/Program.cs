using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Task1_2
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Выберите номер задания от 1 до 4, 0 - для выхода:");
                    switch (Convert.ToInt32(Console.ReadLine()))
                    {
                        case 0:
                            return;
                        case 1:
                            Console.WriteLine("AVERAGES");
                            Console.WriteLine("Введите строку:");
                            Console.WriteLine(AverageWordLen(Console.ReadLine()));
                            break;
                        case 2:
                            Console.WriteLine("Введите 1-ую строку:");
                            string s = Console.ReadLine();
                            Console.WriteLine("Введите 2-ую строку:");
                            string s1 = Console.ReadLine();
                            Console.WriteLine(Doubler(s, s1));
                            break;
                        case 3:
                            Console.WriteLine("LOWERCASE");
                            Console.WriteLine("Введите строку:");
                            Console.WriteLine(CountLowerFirstLattersOnMax(Console.ReadLine()));
                            break;
                        case 4:
                            Console.WriteLine("VALIDATOR");
                            Console.WriteLine("Введите строку:");
                            Console.WriteLine(Validator(Console.ReadLine()));
                            break;
                        default:
                            Console.WriteLine("Тут нет таких заданий");
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Нужно ввести число");
                }
            }
        }

        //Task 1.2.1
        //Результат не округляется
        public static double AverageWordLen(string s)
        {
            StringBuilder sb = new StringBuilder();
            int count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsLetterOrDigit(s[i])) count++;
                if (!char.IsPunctuation(s[i])) sb.Append(s[i]);
            }
            int len = sb.ToString().Split(" ", StringSplitOptions.RemoveEmptyEntries).Length;
            return (double)count / len;
        }

        //Task 1.2.2
        public static string Doubler(string s, string s1)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                if (s1.Contains(s[i].ToString())) sb.Append(s[i], 2);
                else sb.Append(s[i].ToString());
            }
            return sb.ToString();
        }
       
        //Task 1.2.3 
        public static int CountLowerFirstLattersOnMax(string s) =>
         s.Split(new[] { ';', ':', ',' ,' '}, StringSplitOptions.RemoveEmptyEntries).Count(x => char.IsLower(x[0]));

        public static int CountLowerFirstLatters(string s)
        {
            int count = 0;
            bool flag = char.IsLower(s.Trim()[0]);
            char[] separators = { ',', ':', ';', ' ' };

            for (int i = 0; i < s.Length; i++)
            {
                if (flag && char.IsLower(s[i]))
                {
                    count++;
                    flag = false;
                    continue;
                }
                else flag = false;
                if (separators.Contains(s[i])) flag = true;
            }
            return count;
        }

        //Task 1.2.4
        public static string Validator(string s)
        {
            StringBuilder sb = new StringBuilder();
            bool upper = true;
            char[] symbols = { '!','?','.' };
            for (int i = 0; i < s.Length; i++)
            {
                if (upper && char.IsLetter(s[i]))
                {
                    sb.Append(s[i].ToString().ToUpper());
                    upper = false;
                    continue;
                }
                if (symbols.Contains(s[i])) upper = true;
                sb.Append(s[i]);
            }
            return sb.ToString();
        }
        public static string ValidatorWithReg(string s) =>
            Regex.Replace(s, @"(^\s*[а-яa-z])|((\.|\?|\!)(\s*)([а-яa-z]))", m => m.Value.ToUpper());
    }
}
