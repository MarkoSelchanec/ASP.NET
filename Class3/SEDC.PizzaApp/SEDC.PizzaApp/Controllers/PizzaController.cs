using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Models;
using SEDC.PizzaApp.Models.Domain;
using SEDC.PizzaApp.Models.Mappers;
using SEDC.PizzaApp.Models.ViewModels;

namespace SEDC.PizzaApp.Controllers
{
    public class PizzaController : Controller
    {
        List<PizzaViewModel> pizzas = new List<PizzaViewModel>();
        public IActionResult Index()
        {
            ViewData.Add("Title", "Index");
            foreach (Pizza pizza in StaticDb.Pizzas)
            {
                pizzas.Add(PizzaViewModelMapper.PizzaViewModel(pizza));
            }
            return View(pizzas); // returns ViewResult
        }

        public IActionResult JsonData()
        {
            Pizza pizza = new Pizza
            {
                Id = 1,
                Name = "Capri"
            };
            return new JsonResult(pizza); // returns JsonResult
        }

        public IActionResult BackToHome()
        {
            return RedirectToAction("Index", "Home"); //redirects to Action Index in Home Controller
        }

        public IActionResult Details(int? id) // localhost:port/Pizza/Details/1 or  localhost:port/Pizza/Details
        {
            ViewData.Add("Title", "Details");
            if (id != null)
            {
                var pizza = StaticDb.Pizzas.SingleOrDefault(x => x.Id == id);
                ViewBag.Name = pizza.Name;
                ViewBag.Price = pizza.Price;
                return View();
            }
            return new EmptyResult();
        }
    }
}