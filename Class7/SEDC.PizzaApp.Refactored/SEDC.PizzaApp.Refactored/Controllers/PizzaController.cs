using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Services.Interfaces;
using SEDC.PizzaApp.ViewModels.Pizza;

namespace SEDC.PizzaApp.Refactored.Controllers
{
    public class PizzaController : Controller
    {
        private IPizzaService _pizzaService;
        public PizzaController(IPizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }
        public IActionResult Index()
        {
            List<PizzaDetailsViewModel> pizzaDetailsViewModels = _pizzaService.GetAllPizzas();
            return View(pizzaDetailsViewModels);
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return View("BadRequest");
            }

            try
            {
                PizzaDetailsViewModel pizzaDetailsViewModel = _pizzaService.GetPizzaById(id.Value);
                return View(pizzaDetailsViewModel);
            }
            catch (Exception ex)
            {
                return View("ExceptionView");
            }
        }
        public IActionResult CreatePizza()
        {
            PizzaViewModel pizzaViewModel = new PizzaViewModel();
            ViewBag.Pizzas = _pizzaService.GetPizzasForDropdown();
            return View(pizzaViewModel);
        }

        [HttpPost]
        public IActionResult CreatePizzaPost(PizzaViewModel pizzaViewModel)
        {
            try
            {
                _pizzaService.CreatePizza(pizzaViewModel);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View("ExceptionView");
            }

        }
    }
}
