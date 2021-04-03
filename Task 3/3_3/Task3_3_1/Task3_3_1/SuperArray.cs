using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace Task3_3_1
{
    public static class SuperArray
    {
        public static void ActionWithEachEl<T>(this T[] arr, Func<T,T> func)
        {
            if (func != null)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = func(arr[i]);
                }
            }
        }
        public static int Sum(this int[] arr) 
        {
            int sum = 0;
            foreach (var item in arr)
            {
                sum += item;
            }
            return sum;
        }
        public static double Average(this int[] arr) => (double)arr.Sum() / arr.Length;
        public static int MostFrequentlyEl(this int[] arr) => arr.GroupBy(x => x).OrderByDescending(x => x.Count()).First().Key;
    }
}
