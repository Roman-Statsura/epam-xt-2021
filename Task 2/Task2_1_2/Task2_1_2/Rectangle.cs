using System;

namespace Task2_1_2
{
    public class Rectangle : Figure, IAreaCountable, IPerimetrCountable
    {
        private readonly Line A;
        private readonly Line B;
        public Rectangle(int a, int b)
        {
            A = new Line(a);
            B = new Line(b);
            name = "Прямоугльник";
        }
        public int Perimetr() => 2 * (A.Side + B.Side);
        public double Area() => A.Side * B.Side;
    }
}
