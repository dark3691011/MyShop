using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyShop.Helpers;
using MyShop.Models;
using MyShop.ViewModels;

namespace MyShop.Controllers
{
    [Authorize]
    public class CheckOutController : Controller
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;

        public CheckOutController(MyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public IActionResult Index(int? id)
        {
            if (id.HasValue)
            {
                Customer customer = _context.customers.SingleOrDefault(p => p.CustomerID == id);
                var customerView = _mapper.Map<CheckOutViewModel>(customer);
                return View(customerView);
            }
            return RedirectToAction("Index","Home");
        }

        [HttpPost]
        public IActionResult Index(int id,CheckOutViewModel customerView)
        {
            if (ModelState.IsValid)
            {
                Customer customer = _context.customers.SingleOrDefault(p => p.CustomerID == id);
                customer.Name = customerView.Name;
                customer.Addres = customerView.Addres;
                customer.PhoneNumber = customerView.PhoneNumber;
                _context.Update(customer);
                _context.SaveChanges();
                var data = new List<CartItem>();
                HttpContext.Session.Set("Cart", data);
            }
            return RedirectToAction("Index","Home");
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
    }
}