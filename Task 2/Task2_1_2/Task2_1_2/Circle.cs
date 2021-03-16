using System;

namespace Task2_1_2
{
    public class Circle : Figure, ICircumferenceCalculatable
    {
        public (int, int) Coordinates { get; private set; }
        public int Radius { get; private set; }
        public Circle(int x, int y, int rad)
        {
            Coordinates = (x, y);
            Radius = rad;
            name = "Окружность";
        }
        public double Circumference() => 2 * Math.PI * Radius;
    }
}
