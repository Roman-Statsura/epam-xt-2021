using System;

namespace Task2_1_2
{
    public abstract class Figure
    {
        protected string name;
        public override string ToString()
        {
            return name;
        }
        public void SuccessfullyCreated()
        {
            Console.WriteLine($"Фигура {name} успешно созданна!");
        }
    }
}
