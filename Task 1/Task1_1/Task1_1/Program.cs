using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Task1_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите номер задания(1-10), 0 - выход: ");
            try
            {
                int n = Convert.ToInt32(Console.ReadLine());
                switch (n)
                {
                    case 0:
                        return;
                    case 1:
                        Rectangle();
                        break;
                    case 2:
                        DrawTriangle();
                        break;
                    case 3:
                        DrawAnotherTriangle();
                        break;
                    case 4:
                        DrawTree();
                        break;
                    case 5:
                        SumOfNumbers();
                        break;
                    case 6:
                        ChangeFont();
                        break;
                    case 7:
                        PrintArrAndValues();
                        break;
                    case 8:
                        ReplacePosNumInArr();
                        break;
                    case 9:
                        SumOfNonNegative();
                        break;
                    case 10:
                        SumOf2dArray();
                        break;
                    default:
                        Console.WriteLine(Environment.NewLine+"Ну...тут нет таких заданий");
                        break;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Тут надо вводить число");
            }
        }

        //Task 1.1.1
        public static void Rectangle()
        {
            Console.WriteLine("RECTANGLE");
            try
            {
                Console.WriteLine("Введите число А:");
                int x = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите число В:");
                int y = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                if (x <= 0 || y <= 0)
                {
                    Console.WriteLine("Ну какая тебе площадь с некорректными данными?!");
                }
                else Console.WriteLine(x * y);
            }
            catch (Exception)
            {
                Console.WriteLine("Число! Число надо было вводить");
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        //Task 1.1.2
        public static void DrawTriangle()
        {
            Console.WriteLine("TRIANGLE");
            Console.WriteLine("Введите кол-во строк:");
            try
            {
                int n = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                for (int i = 1; i <= n; i++)
                {
                    for (int j = 1; j <= i; j++)
                    {
                        Console.Write("*");
                    }
                    Console.WriteLine();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Тут должно было быть число");
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        //Task 1.1.3
        public static void DrawAnotherTriangle()
        {
            Console.WriteLine("ANOTHER TRIANGLE");
            Console.WriteLine("Введите кол-во строк:");
            try
            {
                int n = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                for (int i = 0; i < n; i++)
                {
                    for (int z = n - 1; z > i; z--)
                    {
                        Console.Write(" ");
                    }
                    for (int j = 1; j <= i * 2 + 1; j++)
                    {
                        Console.Write("*");
                    }
                    Console.WriteLine();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Я же по-человечески просил ввести число");
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        //Task 1.1.4
        public static void DrawTree()
        {
            Console.WriteLine("X-MAS TREE");
            Console.WriteLine("Введите кол-во треугольников:");
            try
            {
                int n = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                for (int k = 1; k <= n; k++)
                {
                    for (int i = 0; i < k; i++)
                    {
                        for (int z = n - 1; z > i; z--)
                        {
                            Console.Write(" ");
                        }
                        for (int j = 1; j <= i * 2 + 1; j++)
                        {
                            Console.Write("*");
                        }
                        Console.WriteLine();
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("число должно было быть тут,ало");
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        //Task 1.1.5
        public static void SumOfNumbers()
        {
            Console.WriteLine("SUM OF NUMBERS");
            int sum = 0;
            for (int i = 3; i < 1000; i++)
            {
                if (i % 3 == 0 || i % 5 == 0) sum += i;
            }
            Console.WriteLine(sum);
        }

        //Task 1.1.6
        public static void ChangeFont()
        {
            Console.WriteLine("FONT ADJUSTMENT");
            Dictionary<string, bool> fonts = new Dictionary<string, bool> { { "Bold", false }, { "Italic", false }, { "Underline", false } };
            while (true)
            {
                try
                {
                    var activeFonts = from t in fonts where t.Value select t.Key;
                    string s = string.Join(", ", activeFonts);
                    Console.WriteLine("Параметры надписи: " + (string.IsNullOrEmpty(s) ? "None" : s));
                    Console.WriteLine("Введите номер параметра,0 - для сохранения изменений:");
                    int j = 1;
                    foreach (KeyValuePair<string, bool> item in fonts)
                    {
                        Console.WriteLine("\t" + j + ": " + item.Key.ToLower());
                        j++;
                    }
                    int num = Convert.ToInt32(Console.ReadLine());
                    if (num == 0) return;
                    string key = fonts.Keys.ElementAt(num - 1);
                    fonts[key] = !fonts[key];
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Error! Вы ввели номер,которого нет в списке");
                    Console.WriteLine();
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error! Так-то нужно вводить число");
                    Console.WriteLine();
                }
            }
        }

        //Task 1.1.7
        public static void PrintArrAndValues()
        {
            Console.WriteLine("ARRAY PROCESSING");
            int[] array = CreateArray();
            Console.WriteLine("Начальный массив:");
            foreach (var item in array) Console.Write(item + " ");
            Console.WriteLine(Environment.NewLine + "Отсортированный массив:");
            int[] sortedArray = SortArray(array);
            foreach (var item in sortedArray) Console.Write(item + " ");
            Console.WriteLine(Environment.NewLine + "Минимально значение: " + sortedArray[0]);
            Console.WriteLine("Максимальное значение: " + sortedArray[^1]);
        }
        public static int[] CreateArray()
        {
            int[] array = new int[30];
            Random r = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = r.Next(-100, 100);
            }
            return array;
        }
        public static int[] SortArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        int tmp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = tmp;
                    }
                }
            }
            return arr;
        }

        //Task 1.1.8
        public static void ReplacePosNumInArr()
        {
            Console.WriteLine("NO POSITIVE");
            int[,,] arr3 = new int[5, 5, 5];
            Random r = new Random();
            for (int i = 0; i < arr3.GetLength(0); i++)
            {
                for (int j = 0; j < arr3.GetLength(1); j++)
                {
                    for (int k = 0; k < arr3.GetLength(2); k++)
                    {
                        arr3[i, j, k] = r.Next(-50, 50);
                    }
                }
            }
            for (int i = 0; i < arr3.GetLength(0); i++)
            {
                for (int j = 0; j < arr3.GetLength(1); j++)
                {
                    for (int k = 0; k < arr3.GetLength(2); k++)
                    {
                        if (arr3[i, j, k] > 0) arr3[i, j, k] = 0;
                    }
                }
            }
        }

        //Task 1.1.9
        public static void SumOfNonNegative()
        {
            Console.WriteLine("NON-NEGATIVE SUM");
            int[] arr = CreateArray();
            int sum = 0;
            foreach (var item in arr)
            {
                if (item > 0) sum += item;
            }
            Console.WriteLine("Сумма неотрицательных эл-ов массива равна: " + sum);
        }

        //Task 1.1.10
        public static void SumOf2dArray()
        {
            Console.WriteLine("2D ARRAY");
            int[,] arr = Create2DArray();
            int sum = 0;
            for (int i = 1; i < arr.GetLength(0); i++)
            {
                for (int j = 1; j < arr.GetLength(1); j++)
                {
                    if ((i + j) % 2 == 0) sum += arr[i, j];
                }
            }
            Console.WriteLine("Сумма числе равна: " + sum);
        }
        public static int[,] Create2DArray()
        {
            int[,] arr = new int[10, 10];
            Random r = new Random();
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = r.Next(-50, 50);
                }
            }
            return arr;
        }
    }
}