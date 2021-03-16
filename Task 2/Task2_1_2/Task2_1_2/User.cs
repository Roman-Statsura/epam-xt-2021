using System;
using System.Collections.Generic;

namespace Task2_1_2
{
    public class User
    {
        private readonly string name;
        private List<Figure> canvas = new List<Figure>();
        public User(string name) => this.name = name;
        public string GetName()
        {
            return name;
        }
        public void ClearCanvas()
        {
            canvas.Clear();
        }
        public List<Figure> GetCanvas()=> canvas;
        
        public void AddToCanvas(Figure f)
        {
            canvas.Add(f);
        }
        public override string ToString()
        {
            return name;
        }
    }
}
