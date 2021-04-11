using System;
using System.Collections.Generic;
using System.Text;

namespace Task3_3_3
{
    public class Order
    {
        public int Id { get; set; }
        public Pizza Pizza { get; set; }
        public Order(int id,Pizza pizza)
        {
            Id = id;
            Pizza = pizza;
        }
        public void OrderCreated(string UserName)
        {
            Console.WriteLine($"Заказ № {Id}: Пицца {Pizza.Name}. {UserName}, " +
                $"пицца будет готова через {Pizza.CokingTime} минут.");
        }
    }
}
