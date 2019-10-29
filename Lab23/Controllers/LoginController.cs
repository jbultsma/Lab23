using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab23.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab23.Controllers
{
    public class LoginController : Controller
    {
        ShopContext db = new ShopContext();       

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Users u)
        {
            if (db.Users.Contains(u))
            {
                ViewBag.Error = "That user already exists";
                return View();
            }
            else
            {
                db.Users.Add(u);
                db.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string Name, string Password)
        {
            List<Users> users = db.Users.ToList();

            for(int i = 0; i < users.Count; i++)
            {
                Users u = users[i];
                if (u.Name == Name && u.Password == Password)
                {
                    TempData["Users"] = u;
                }
            }

            ViewBag.Error = "Incorrect UserName or Password, Please try again or Register";

            return View();
        }
    }
}