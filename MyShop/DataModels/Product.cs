using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.DataModels
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string UnitPrice { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }


        public int DiscountID { get; set; }
        [ForeignKey("DiscountID")]
        public Discount Discount { get; set; }

        public int TypeID { get; set; }
        [ForeignKey("TypeID")]
        public ProductType ProductType { get; set; }

        public int TrademarkID { get; set; }
        [ForeignKey("TrademarkID")]
        public Trademark Trademark { get; set; }

        public int ImgID { get; set; }
        [ForeignKey("ImgID")]
        public ImgProduct ImgProduct { get; set; }
    }
}
