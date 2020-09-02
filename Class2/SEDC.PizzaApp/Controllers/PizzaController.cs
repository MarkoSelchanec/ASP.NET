using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Models;

namespace SEDC.PizzaApp.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult JsonData()
        {
            Pizza pizza = new Pizza()
            {
                Id = 1,
                Name = "Capri"
            };

            return new JsonResult(pizza);
        }
        public IActionResult BackToHome()
        {
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Details(int? Id)
        {
            if(Id != null)
            {
                return View();
            }
            return new EmptyResult();
        }
    }
}
