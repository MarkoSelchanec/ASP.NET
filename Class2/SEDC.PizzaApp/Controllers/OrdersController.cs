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
        [Route("SeeOrders")][Route("Orders")]
        public IActionResult Index()
        {
            var Orders = OrdersList.Orders;
            return View(Orders);
        }
        public IActionResult Details(int? id)
        {
            var Order = OrdersList.Orders.Where((x) => x.Id == id).FirstOrDefault();
            if (id == null || Order == null)
            {
                return new EmptyResult();
            }
            return View(Order);
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
