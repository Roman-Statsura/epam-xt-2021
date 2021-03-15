using System;

namespace Task2_1_2
{
    public class Round : Circle, IAreaCountble
    {
        public Round(int x, int y, int rad)
            : base(x, y, rad)
        {
            name = "Круг";
        }
        public double Area() => Math.PI * Radius * Radius;
    }
}
