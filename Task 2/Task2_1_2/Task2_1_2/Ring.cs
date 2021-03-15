using System;

namespace Task2_1_2
{
    public class Ring : Figure, IAreaCountble, ICircumferenceCalculateble
    {
        private readonly Round innerRound;
        private readonly Round outRound;
        public Ring(int x, int y, int innerRad, int outRad)
        {
            if (outRad > innerRad)
            {
                innerRound = new Round(x, y, innerRad);
                outRound = new Round(x, y, outRad);
                name = "Кольцо";
            }
            else throw new Exception("Внешний радиус не может быть меньше внутреннего");
        }
        public double Circumference() => 2 * Math.PI * (innerRound.Radius + outRound.Radius);
        public double Area() => outRound.Area() - innerRound.Area();
    }
}
