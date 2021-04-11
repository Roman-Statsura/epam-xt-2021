using System;
using System.Collections.Generic;
using System.Text;

namespace Task3_3_3
{
    public class User
    {
        public event EventHandler<TypeOfPizza> UserEvent;
        public string Name { get; }
        public User(string name)
        {
            Name = name;
        }
        public void PickUpOrder(TypeOfPizza PizzaName)
        {
            UserEvent?.Invoke(this, PizzaName);
        }
    }
}
