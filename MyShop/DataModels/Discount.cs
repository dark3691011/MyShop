using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.DataModels
{
    public class Discount
    {
        [Key]
        public int DiscountID { get; set; }
        public int DiscountValue { get; set; }
        public DateTime ExpirationDay { get; set; }

    }
}
