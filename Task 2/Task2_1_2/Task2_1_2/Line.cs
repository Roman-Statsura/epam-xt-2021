using System;

namespace Task2_1_2
{
    public class Line : Figure
    {
        public int Side { get; set; }
        public Line(int side)
        {
            Side = side;
            name = "Линия";
        }
    }
}
