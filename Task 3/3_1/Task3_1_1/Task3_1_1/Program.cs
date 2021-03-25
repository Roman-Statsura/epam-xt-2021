using System;
using System.Collections;

namespace Task3_1_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите N: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите, какой по счету человек будет вычеркнут каждый раунд: ");
            int step = Convert.ToInt32(Console.ReadLine());
            if (step > n)
            {
                Console.WriteLine("Некорректные данные!");
                return;
            }
            MySuperCollection<int> customIntCollection = new MySuperCollection<int>(1,n);
            int i = 0;
            int round = 1;
            IEnumerator ie = customIntCollection.GetEnumerator();
            while (ie.MoveNext())
            {
                if (customIntCollection.Count < step || customIntCollection.Count == 1)
                {
                    Console.WriteLine("Игра закончилась. Невозможно вычеркнуть больше людей");
                    break;
                }
                ++i;
                int item = (int)ie.Current;
                if (i % step == 0)
                {
                    if (item != customIntCollection[^1]) i++;
                    customIntCollection.Remove(item);
                    Console.WriteLine($"Раунд {round}. Вычеркнут человек. Людей осталось: {customIntCollection.Count}");
                    round++;
                }
            }
        }
    }
}
