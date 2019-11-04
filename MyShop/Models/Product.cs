using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Models
{
    public class Product
    {
        [Key]
        [Display(Name ="Mã sản phẩm")]
        [Required]
        public int ProductID { get; set; }
        [Display(Name ="Tên sản phẩm")]
        [MaxLength(100)]
        [Required(ErrorMessage ="Phải nhập tên sản phẩm")]
        public string ProductName { get; set; }
        [Display(Name ="Đơn giá")]
        [Required(ErrorMessage ="Phải nhập giá sản phẩm")]
        public double UnitPrice { get; set; }
        [Display(Name ="Số lượng")]
        [Required(ErrorMessage ="Phải nhập số lượng")]
        public int Amount { get; set; }
        [Display(Name ="Mô tả chi tiết")]
        [MaxLength(255)]
        public string Description { get; set; }
        [MaxLength(50)]
        [Required(ErrorMessage ="Phải có hình ảnh")]
        [Display(Name = "Hình sản phẩm")]
        public string ProductImage { get; set; }


        [Display(Name ="Mã giảm giá")]
        public int? DiscountID { get; set; }
        [ForeignKey("DiscountID")]
        public Discount Discount { get; set; }

        [Display(Name ="Mã loại")]
        public int TypeID { get; set; }
        [ForeignKey("TypeID")]
        public ProductType ProductType { get; set; }

        [Display(Name ="Mã thương hiệu")]
        public int TrademarkID { get; set; }
        [ForeignKey("TrademarkID")]
        public Trademark Trademark { get; set; }
    }
}
