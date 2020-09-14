using System;
using System.Collections.Generic;
using System.Text;
using SEDC.PizzaApp.DataAccess;
using SEDC.PizzaApp.Domain.Models;
using SEDC.PizzaApp.Mappers.Pizza;
using SEDC.PizzaApp.Services.Interfaces;
using SEDC.PizzaApp.ViewModels.Pizza;

namespace SEDC.PizzaApp.Services.Implementations
{
    public class PizzaService: IPizzaService
    {
        private IRepository<Pizza> _pizzaRepository;

        public PizzaService(IRepository<Pizza> pizzaRepository)
        {
            _pizzaRepository = pizzaRepository ;
        }
        public List<PizzaDDViewModel> GetPizzasForDropdown()
        {
            List<Pizza> pizzas = _pizzaRepository.GetAll();
            List<PizzaDDViewModel> pizzaDdViewModels = new List<PizzaDDViewModel>();
            foreach (Pizza pizza in pizzas)
            {
                pizzaDdViewModels.Add(pizza.ToPizzaDdViewModel());
            }

            return pizzaDdViewModels;
        }
    }
}
