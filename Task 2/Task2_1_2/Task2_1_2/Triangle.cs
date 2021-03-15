using System;

namespace Task2_1_2
{
    public class Triangle : Figure, IAreaCountble, IPerimetrCountble
    {
        private readonly Line A;
        private readonly Line B;
        private readonly Line C;
        public Triangle(int a, int b, int c)
        {
            A = new Line(a);
            B = new Line(b);
            C = new Line(c);
            name = "Треугольник";
        }
        public int Perimetr() => A.Side + B.Side + C.Side;
        public double Area() => Math.Sqrt(Perimetr() * (Perimetr() - A.Side) * (Perimetr() - B.Side) * (Perimetr() - C.Side));
    }
}
