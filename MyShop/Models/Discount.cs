using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Models
{
    public class Discount
    {
        [Key]
        [Display(Name ="Mã giảm giá")]
        [MaxLength(20)]
        public int DiscountID { get; set; }
        [Display(Name ="% giảm giá")]
        [Range(0,100)]
        public int DiscountValue { get; set; }
        [Display(Name ="Ngày hết hạn")]
        [MaxLength(20)]
        public DateTime ExpirationDay { get; set; }

    }
}
