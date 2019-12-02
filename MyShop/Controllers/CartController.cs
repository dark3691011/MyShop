using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyShop.Models;
using MyShop.ViewModels;
using MyShop.Helpers;

namespace MyShop.Controllers
{
    public class CartController : Controller
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;

        public CartController(MyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public IActionResult Index()
        {
            return View(Cart);
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
        [HttpPost]
        public IActionResult AddToCart(int productId, int qty, string loai)
        {
            //Lấy giỏ hàng đang có ở Session
            List<CartItem> carts = Cart;

            //tìm xem đã có hàng hóa trong giỏ hàng với mã chọn hay chưa
            CartItem item = carts.SingleOrDefault(p => p.Product.ProductID == productId);
            if (item != null)//đã có
            {
                item.Amount += qty;
            }
            else
            {
                Product product = _context.products.SingleOrDefault(p => p.ProductID == productId);

                if (product == null)//hàng hóa ko có trong Database
                    return RedirectToAction("Error", "Home");
                item = new CartItem
                {
                    Product = _mapper.Map<ProductViewModel>(product),
                    Amount = qty
                };

                carts.Add(item);
            }

            //update lại giỏ hàng
            HttpContext.Session.Set("Cart", carts);

            if (loai == "AJAX")
            {
                return Json(new
                {
                    Amount = Cart.Sum(p => p.Amount),
                    ToltalPrice = Cart.Sum(p => p.TotalPrice)
                });
            }

            return RedirectToAction("Index");
        }

        public IActionResult RemoveCart(int id)
        {
            List<CartItem> carts = Cart;

            CartItem item = carts.SingleOrDefault(p => p.Product.ProductID == id);
            if (item != null)
            {
                carts.Remove(item);

                HttpContext.Session.Set("Cart", carts);
            }

            

            return RedirectToAction("Index");
        }
    }
}