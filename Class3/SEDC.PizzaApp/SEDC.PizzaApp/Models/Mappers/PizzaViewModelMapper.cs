using SEDC.PizzaApp.Models.Domain;
using SEDC.PizzaApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.PizzaApp.Models.Mappers
{
    public static class PizzaViewModelMapper
    {
        public static PizzaViewModel PizzaViewModel(Pizza pizza)
        {
            decimal newPrice = 0;
            if (pizza.HasExtras)
            {
                newPrice = pizza.Price + 10;
            }
            else
            {
                newPrice = pizza.Price;
            }
            return new PizzaViewModel
            {
                Id = pizza.Id,
                Name = pizza.Name,
                Price = newPrice,
                PizzaSize = pizza.PizzaSize
            };
        }
    }
}
