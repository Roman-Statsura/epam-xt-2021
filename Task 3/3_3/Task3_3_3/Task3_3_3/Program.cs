using System;
using System.Threading;

namespace Task3_3_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Pizzeria pizzeria = new Pizzeria();

            User roman = new User("Роман");
            User ignat = new User("Игнат");
            User petr = new User("Петр");

            roman.UserEvent += pizzeria.MakeOrder;
            ignat.UserEvent += pizzeria.MakeOrder;
            petr.UserEvent += pizzeria.MakeOrder;

            roman.PickUpOrder(TypeOfPizza.FourCheeses);
            ignat.PickUpOrder(TypeOfPizza.Mexican);
            petr.PickUpOrder(TypeOfPizza.Pepperoni);
        }  
    }
}
