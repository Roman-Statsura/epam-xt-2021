using System;

namespace StringClassLibrary
{
    public class Str : IComparable
    {
        private readonly char[] s;
        public Str(char[] mass)
        {
            s = new char[mass.Length];
            mass.CopyTo(s, 0);
        }
        public Str(string st)
        {
            char[] mass = st.ToCharArray();
            s = new char[mass.Length];
            mass.CopyTo(s, 0);
        }
        public void Print()
        {
            for (int i = 0; i < s.Length; i++)
            {
                Console.Write(s[i]);
            }
            Console.WriteLine();
        }
        public int GetLength()
        {
            return s.Length;
        }
        public Str StrMultiply(int m)
        {
            if (m > 0)
            {
                char[] mass = new char[s.Length * m];
                for (int i = 0; i < m; i++)
                {
                    s.CopyTo(mass, i * s.Length);
                }
                return new Str(mass);
            }
            else return new Str(new char[0]);
        }
        public int CastIndexOf(char x) => Array.IndexOf(s, x);

        private void CastCopy(ref char[] c, int ind)
        {
            for (int i = 0, j = ind; i < s.Length; i++, j++)
            {
                c[j] = s[i];
            }
        }
        public char[] ConvertToCharArr()
        {
            return s;
        }
        public static Str operator +(Str x, Str y)
        {
            char[] z = new char[x.GetLength() + y.GetLength()];
            x.CastCopy(ref z, 0);
            y.CastCopy(ref z, x.GetLength());

            return new Str(z);
        }
        public static bool operator ==(Str x, Str y)
        {
            return x.Equals(y);
        }
        public static bool operator !=(Str x, Str y)
        {
            return !x.Equals(y);
        }
        private char GetById(int id)
        {
            return s[id];
        }
        private void AddOrUpdate(int id, char un)
        {
            s[id] = un;
        }
        public char this[int id]
        {
            get
            {
                return GetById(id);
            }
            set
            {
                AddOrUpdate(id, value);
            }
        }
        public static explicit operator char[](Str z)
        {
            char[] mass = new char[z.GetLength()];
            for (int i = 0; i < z.GetLength(); i++)
            {
                mass[i] = z[i];
            }
            return mass;
        }
        public int CompareTo(object obj)
        {
            Str str = obj as Str;
            if (str != null)
            {

                if (s.Length != str.GetLength()) return -1;
                for (int i = 0; i < str.GetLength(); i++)
                {
                    if (s[i] != str[i])
                    {
                        return -1;
                    }
                }
                return 1;
            }
            else
                throw new Exception("Невозможно сравнить два объекта");
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this)) return true;
            if (!(obj is Str)) return false;

            Str str = new Str(s);

            return str.CompareTo(obj) == 1;
        }

        public override int GetHashCode()
        {
            int hc = s.Length;
            for (int i = 0; i < s.Length; i++)
            {
                hc = (hc * 314159 + s[i]);
            }
            return hc;
        }
    }
}
