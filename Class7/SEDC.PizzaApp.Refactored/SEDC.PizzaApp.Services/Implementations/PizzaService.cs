using System;
using System.Collections.Generic;
using System.Text;
using SEDC.PizzaApp.DataAccess;
using SEDC.PizzaApp.Domain.Models;
using SEDC.PizzaApp.Mappers.Pizza;
using SEDC.PizzaApp.Services.Interfaces;
using SEDC.PizzaApp.ViewModels.Order;
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

        public List<PizzaDetailsViewModel> GetAllPizzas()
        {
            //call to data access layer
            List<Pizza> pizzas = _pizzaRepository.GetAll();
            List<PizzaDetailsViewModel> PizzaDetailsViewModel = new List<PizzaDetailsViewModel>();
            foreach (Pizza pizza in pizzas)
            {
                PizzaDetailsViewModel.Add(pizza.ToPizzaDetailsViewModel());
            }

            return PizzaDetailsViewModel;
        }

        public PizzaDetailsViewModel GetPizzaById(int id)
        {
            Pizza pizza = _pizzaRepository.GetById(id);
            if (pizza == null)
            {
                //log the exception
                throw new Exception($"Pizza with id {id} does not exist!");
            }

            return pizza.ToPizzaDetailsViewModel();
        }

        public void CreatePizza(PizzaViewModel pizzaViewModel)
        {
            Pizza pizza = pizzaViewModel.ToPizza();
            foreach (Pizza pizz in _pizzaRepository.GetAll())
            {
                if(pizz.Name == pizza.Name)
                {
                    throw new Exception($"Pizza with name {pizz.Name} already exists!");
                }
            }
            int newPizzaId = _pizzaRepository.Insert(pizza);
            if (newPizzaId <= 0)
            {
                throw new Exception("Something went wrong while saving the new order");
            }
        }
    }
}
