using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Models.Domain;

namespace SEDC.PizzaApp.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Users: ";
            List<User> users = StaticDb.Users;
            return View(users); // returns ViewResult
        }
        public IActionResult CreateUser()
        {
            User user = new User();
            return View(user);
        }
        [HttpPost]
        public IActionResult CreateUserPost(User user)
        {
            user.Id = ++StaticDb.UserId;
            if (user.FirstName == null ||
                user.LastName == null ||
                user.Address == null)
                return View("BadRequest");
            StaticDb.Users.Add(user);
            return RedirectToAction("Index");
        }
        public IActionResult EditUser(int? id)
        {
            if (id == null)
            {
                return View("BadRequest");
            }
            User user = StaticDb.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return View("ResourceNotFound");
            }
            return View(user);
        }
        [HttpPost]
        public IActionResult EditUserPost(User user)
        {
            int index = StaticDb.Users.FindIndex(x => x.Id == user.Id);
            StaticDb.Users[index] = user;
            return RedirectToAction("Index");
        }
        public IActionResult DeleteUser(int? id)
        {
            if (id == null)
                return View("BadRequest");
            //we have to validate if the order we want to delete exists
            User user = StaticDb.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return View("ResourceNotFound");
            }
            if (StaticDb.Orders.Count(x => x.User.Id == user.Id) > 0)
                return View("ForbiddenAction");
            //we are sending view model to the view
            return View(user);
        }
        [HttpPost]
        public IActionResult DeleteUserPost(User user)
        {
            int index = StaticDb.Users.FindIndex(x => x.Id == user.Id);
            if (index == -1)
                return View("ResourceNotFound");
            StaticDb.Users.RemoveAt(index);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult ConfirmDelete(int id)
        {
            //find the index of the order
            var index = StaticDb.Users.FindIndex(x => x.Id == id);
            //check if the order exists
            if (index == -1)
                return View("ResourceNotFound");
            StaticDb.Users.RemoveAt(index);
            return RedirectToAction("Index");
        }
    }
}
