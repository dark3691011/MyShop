using Microsoft.AspNetCore.Mvc;
using MyShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.ViewComponents
{
    public class CategoryMenu : ViewComponent
    {
        private readonly MyDbContext _context;
        public CategoryMenu(MyDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke(int tmp)
        {
            string MyView = "Default";
            switch (tmp)
            {
                case 1:
                    MyView = "Default";
                    break;
                case 2:
                    MyView = "SubMenu";
                    break;
            }
            return View(MyView,_context.productTypes);
        }
    }
}
