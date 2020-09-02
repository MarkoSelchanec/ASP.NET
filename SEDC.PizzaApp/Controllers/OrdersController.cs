using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Models;

namespace SEDC.PizzaApp.Controllers
{
    public class OrdersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Details(int? id)
        {
            if(id == null)
            {
                return new EmptyResult();
            }
            var Orders = OrdersList.Orders;
            return View(Orders);
        }
        public IActionResult JsonData()
        {
            Employee Jason = new Employee
            {
                Id = 1,
                Name = "Jason Statham"
            };
            return new JsonResult(Jason);
        }
        public IActionResult ReturnHome()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
