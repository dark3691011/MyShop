using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyShop.Models;
using MyShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.ViewComponents
{
    public class RelatedProduct : ViewComponent
    {
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;
        public RelatedProduct(MyDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public IViewComponentResult Invoke(string page)
        {
            string MyView = "Home";
            if (page == "Contact" || page=="Home2")
            {
                MyView = page;
            }
            List<Product> products = _context.products.Include(p => p.Trademark).Include(p => p.Discount).Include(p => p.ProductType).ToList();
            var productsView = _mapper.Map<List<ProductViewModel>>(products);
            ViewBag.Data = productsView;
            return View(MyView);
        }
    }
}
