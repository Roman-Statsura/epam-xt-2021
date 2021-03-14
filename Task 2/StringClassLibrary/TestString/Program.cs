using System;
using StringClassLibrary;

namespace TestString
{
    class Program
    {
        static void Main(string[] args)
        {
            Str s = new Str("string".ToCharArray());
            Str s2 = new Str("hi".ToCharArray());
            s.Print();
            Str s1 = new Str("privet".ToCharArray());
            Console.WriteLine(s == s1);
            Console.WriteLine(s.CastIndexOf('t'));
            Console.WriteLine(s[0]);
            Str sum = s + s2;
            sum.Print();
            Str st = new Str("string");
            Str sum1 = st + s;
            sum1.Print();
            Str mult = st.StrMultiply(3);
            mult.Print();
            Console.WriteLine(st.Equals(s));
            Console.WriteLine(st.GetHashCode());
            Console.WriteLine(s.GetHashCode());
            Console.WriteLine(s == st);
        }
    }
}
