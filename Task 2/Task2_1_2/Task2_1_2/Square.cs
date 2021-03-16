using System;

namespace Task2_1_2
{
    public class Square : Figure, IAreaCountable, IPerimetrCountable
    {
        private readonly Line A;
        public Square(int a)
        {
            A = new Line(a);
            name = "Квадрат";
        }
        public int Perimetr() => 4 * A.Side;
        public double Area() => A.Side * A.Side;
    }
}
