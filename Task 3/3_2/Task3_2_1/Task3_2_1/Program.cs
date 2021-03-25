using System;

namespace Task3_2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            DynamicArray<int> arr = new DynamicArray<int>();
            arr.Add(1);
            arr.Add(2);
            arr.Insert(0, 10);
            arr.Insert(1, 25);
            arr.Add(120);
            arr.Insert(4, -9);
            arr.Add(88);

            arr.Remove(0);
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
            Console.WriteLine(arr[5]+"!");
            Console.WriteLine(arr.Length);
            Console.WriteLine(arr.Capacity);
        }
    }
}
