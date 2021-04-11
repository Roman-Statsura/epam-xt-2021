using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;

namespace Task3_3_3
{
    class Pizzeria
    {
        private int _id = 0;
        public List<Pizza> Pizzas { get; private set; }
        public Pizzeria()
        {
            Pizzas = new List<Pizza>
            {
                new Pizza(TypeOfPizza.FourCheeses,5),
                new Pizza(TypeOfPizza.Hawaiian,9),
                new Pizza(TypeOfPizza.Margarita,7),
                new Pizza(TypeOfPizza.Mexican,8),
                new Pizza(TypeOfPizza.Pepperoni,6),
                new Pizza(TypeOfPizza.Spicy,12)
            };
        }
        public void MakeOrder(object sender, TypeOfPizza PizzaName)
        {
            User user = sender as User;
            var pizzaOrder = Pizzas.FirstOrDefault(x => x.Name == PizzaName);
            if (pizzaOrder is null)
                throw new NullReferenceException("Нет такой пиццы");

            Order order = new Order(++_id, pizzaOrder);
            order.OrderCreated(user.Name);
            Cook(order, user.Name);
        }
        private void Cook(Order order,string UserName)
        {
            Thread.Sleep(order.Pizza.CokingTime*1000);
            Console.WriteLine($"{UserName}, Ваша пицца {order.Pizza.Name} готова." + Environment.NewLine);
            Thread.Sleep(1000);
        }
    }
}
