using System;
using System.Collections.Generic;

namespace ESGI.DesignPattern.Projet
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Order> orders = new List<Order>();
            var order = new Order(1234);
            order.Add(new Product(4321, "T-Shirt", ProductSize.Medium, "21.00"));
            order.Add(new Product(6789, "Socks", ProductSize.Medium, "8.00"));
            orders.Add(order);
            
            var order2 = new Order(2);
            order2.Add(new Product(123, "Polo", ProductSize.ExtraLarge, "458.00"));
            order2.Add(new Product(234, "Gloves", ProductSize.Small, "5.00"));
            
            orders.Add(order2);

            var ordersWriter = new OrdersWriter(orders);
            Console.WriteLine(ordersWriter.GetContents());
        }
    }
}
