using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.ViewModels
{
    public class ProductViewModel
    {
        [Display(Name = "Mã sản phẩm")]
        [Required]
        public int ProductID { get; set; }
        [Display(Name = "Tên sản phẩm")]
        [MaxLength(100)]
        [Required(ErrorMessage = "Phải nhập tên sản phẩm")]
        public string ProductName { get; set; }
        [Display(Name = "Đơn giá")]
        [Required(ErrorMessage = "Phải nhập giá sản phẩm")]
        public double UnitPrice { get; set; }
        [MaxLength(50)]
        [Display(Name = "Hình sản phẩm")]
        public string ProductImage { get; set; }
        public int Discount { get; set; }
    }
}
