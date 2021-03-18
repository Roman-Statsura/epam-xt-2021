using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    public class Canvas
    {
        public static char[,] Field { get; set; }
        public static int WIDTH = 20;
        public static int HEIGHT = 10;
        public Canvas()
        {
            Field = new char [10, 20];
            CreateCanvas();
        }
        private void CreateCanvas()
        {
            for (int i = 0; i < Field.GetLength(0); i++)
            {
                for (int j = 0; j < Field.GetLength(1); j++)
                {
                    Field[i, j] = '.';
                }
            }
        }
        public void PrintCanvas()
        {
            for (int i = 0; i < Field.GetLength(0); i++)
            {
                for (int j = 0; j < Field.GetLength(1); j++)
                {
                    Console.Write(Field[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
