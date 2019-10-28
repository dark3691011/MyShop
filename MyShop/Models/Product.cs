﻿using System;
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
        [MaxLength(50)]
        public int ProductID { get; set; }
        [Display(Name ="Tên sản phẩm")]
        [MaxLength(100)]
        public string ProductName { get; set; }
        [Display(Name ="Đơn giá")]
        [MaxLength(50)]
        public double UnitPrice { get; set; }
        [Display(Name ="Số lượng")]
        [MaxLength(50)]
        public int Amount { get; set; }
        [Display(Name ="Mô tả chi tiết")]
        [MaxLength(255)]
        public string Description { get; set; }
        [MaxLength(50)]
        [Display(Name = "Hình sản phẩm")]
        public string ProductImage { get; set; }
        [MaxLength(50)]
        [Display(Name = "Hình chi tiết sản phẩm")]
        public string SingleImage1 { get; set; }
        [MaxLength(50)]
        [Display(Name = "Hình chi tiết sản phẩm")]
        public string SingleImage2 { get; set; }


        [Display(Name ="Mã giảm giá")]
        [MaxLength(50)]
        public int DiscountID { get; set; }
        [ForeignKey("DiscountID")]
        public Discount Discount { get; set; }

        [Display(Name ="Mã loại")]
        [MaxLength(50)]
        public int TypeID { get; set; }
        [ForeignKey("TypeID")]
        public ProductType ProductType { get; set; }

        [Display(Name ="Mã thương hiệu")]
        [MaxLength(50)]
        public int TrademarkID { get; set; }
        [ForeignKey("TrademarkID")]
        public Trademark Trademark { get; set; }
    }
}