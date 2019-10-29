using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab23.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab23.Controllers
{
    public class ProductsController : Controller
    {
        ShopContext db = new ShopContext();

        public async Task<IActionResult> Index()
        {
            return View(await db.Products.ToListAsync());
        }

        public IActionResult Purchase(int id)
        {
            Products p = db.Products.Find(id);
            if (p != null)
            {
                return View(p);
            }
            else
            {
                return RedirectToAction("Index", "Product");
            }


        }
    }
}