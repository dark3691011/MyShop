using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyShop.Helpers;
using MyShop.Models;
using MyShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.ViewComponents
{
    public class CheckOutCart : ViewComponent
    {
        private readonly MyDbContext _context;
        public CheckOutCart(MyDbContext context)
        {
            _context = context;
        }
        public List<CartItem> Cart
        {
            get
            {
                var data = HttpContext.Session.Get<List<CartItem>>("Cart");
                if (data == null)
                {
                    data = new List<CartItem>();
                }

                return data;
            }
        }
        public IViewComponentResult Invoke()
        {
            return View(Cart);
        }
    }
}
