using System;

namespace Task3_3_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 1,2,3,4,4,1,1};
            arr.ActionWithEachEl(x => x * x);
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(arr.Sum());
            Console.WriteLine(arr.Average());
            Console.WriteLine(arr.MostFrequentlyEl());
        }
    }
}
