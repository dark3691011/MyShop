using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.ViewModels
{
    public class CartItem
    {
        public ProductViewModel Product { get; set; }
        public int Amount { get; set; }
        public double TotalPrice => Amount * Product.UnitPrice * (1- (Product.Discount / 100.0));
    }
}
