using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.ViewModels
{
    public class ProductDetailViewModel
    {
        [Display(Name = "Tên sản phẩm")]
        [MaxLength(100)]
        [Required(ErrorMessage = "Phải nhập tên sản phẩm")]
        public string ProductName { get; set; }
        [Display(Name = "Đơn giá")]
        [Required(ErrorMessage = "Phải nhập giá sản phẩm")]
        public double UnitPrice { get; set; }
        [Display(Name = "Số lượng")]
        [Required(ErrorMessage = "Phải nhập số lượng")]
        public int Amount { get; set; }
        [Display(Name = "Mô tả chi tiết")]
        [MaxLength(255)]
        public string Description { get; set; }
        [MaxLength(50)]
        [Display(Name = "Hình sản phẩm")]
        public string ProductImage { get; set; }
        [Display(Name = "Giảm giá")]
        public int Discount { get; set; } = 0;
        [Display(Name ="Logo thương hiệu")]
        public string Trademark { get; set; }
    }
}
