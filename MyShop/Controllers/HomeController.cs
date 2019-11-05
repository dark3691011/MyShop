using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyShop.Models;
using MyShop.Helpers;

namespace MyShop.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Session()
        {
            //set session
            HttpContext.Session.SetString("Lop", "1911COMP1064");
            HttpContext.Session.SetInt32("Nam", 3);

            ProductType lo = new ProductType
            {
                TypeID = 1,
                TypeName = "Laptop"
            };

            HttpContext.Session.Set<ProductType>("ProductType", lo);

            return View();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
