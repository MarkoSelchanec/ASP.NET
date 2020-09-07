using SEDC.PizzaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.PizzaApp
{
    public class OrdersList
    {
        public static List<Order> Orders = new List<Order>
        {
            new Order()
            {
                Id = 1,
                Description = "Capricioza"
            },
            new Order()
            {
                Id = 2,
                Description = "Pasto"
            },
            new Order()
            {
                Id = 3,
                Description = "SpicyPizza"
            },
            new Order()
            {
                Id = 4,
                Description = "Family sized Capricioza"
            }
        };
    }
}
