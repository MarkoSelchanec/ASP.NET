using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Models;
using SEDC.PizzaApp.Models.Domain;

namespace SEDC.PizzaApp.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Pizza Menu";
            List<Pizza> pizzas = StaticDb.Pizzas;
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
            if (id != null)
            {
                return View();
            }
            //  return new EmptyResult();
            return View("BadRequest");
        }
        public IActionResult CreatePizza()
        {
            Pizza pizza = new Pizza();
            return View(pizza);
        }
        [HttpPost]
        public IActionResult CreatePizzaPost(Pizza pizza)
        {
            pizza.Id = ++StaticDb.PizzaId;
            if (pizza.Name == null || 
                pizza.Price == 0.0m)
                return View("BadRequest");
            Pizza validatePizza = StaticDb.Pizzas.FirstOrDefault(x => x.Name.Equals(pizza.Name));
            if (validatePizza != null && pizza.Name == validatePizza.Name)
                return View("BadRequest");
            StaticDb.Pizzas.Add(pizza);
            return RedirectToAction("Index");
        }
        public IActionResult EditPizza(int? id)
        {
            if(id == null)
            {
                return View("BadRequest");
            }
            Pizza pizza = StaticDb.Pizzas.FirstOrDefault(x => x.Id == id);
            if(pizza == null)
            {
                return View("ResourceNotFound");
            }
            return View(pizza);
        }
        [HttpPost]
        public IActionResult EditPizzaPost(Pizza pizza)
        {
            int index = StaticDb.Pizzas.FindIndex(x => x.Id == pizza.Id);
            StaticDb.Pizzas[index] = pizza;
            return RedirectToAction("Index");
        }
        public IActionResult DeletePizza(int? id)
        {
            if (id == null)
                return View("BadRequest");
            //we have to validate if the order we want to delete exists
            Pizza pizza = StaticDb.Pizzas.FirstOrDefault(x => x.Id == id);
            if (pizza == null)
            {
                return View("ResourceNotFound");
            }
            if (StaticDb.Orders.Count(x => x.Pizza.Id == pizza.Id) > 0)
                return View("ForbiddenAction");
            //we are sending view model to the view
            return View(pizza);
        }
        [HttpPost]
        public IActionResult DeletePizzaPost(Pizza pizza)
        {
            int index = StaticDb.Pizzas.FindIndex(x => x.Id == pizza.Id);
            if (index == -1)
                return View("ResourceNotFound");
            StaticDb.Pizzas.RemoveAt(index);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult ConfirmDelete(int id)
        {
            //find the index of the order
            var index = StaticDb.Pizzas.FindIndex(x => x.Id == id);
            //check if the order exists
            if (index == -1)
                return View("ResourceNotFound");
            StaticDb.Pizzas.RemoveAt(index);
            return RedirectToAction("Index");
        }
    }
}