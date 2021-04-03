using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task3_3_2
{
    public static class SuperString
    {
        public static Languages GetLanguage(this string s)
        {
            char[] arr = s.ToCharArray();
            if (arr.All(c => char.IsDigit(c)))
            {
                return Languages.Number;
            }
            else if (arr.All(c => (c >= 'а' && c <= 'я') || (c >= 'А' && c <= 'Я')))
            {
                return Languages.Russian;
            }
            else if (arr.All(c => (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z')))
            {
                return Languages.English;
            }
            else return Languages.Mixed;
        }
        public enum Languages{
            Russian,
            English,
            Number,
            Mixed
        }
    }
}
