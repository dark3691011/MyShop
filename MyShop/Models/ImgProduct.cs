using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Models
{
    public class ImgProduct
    {
        [Key]
        [MaxLength(50)]
        [Display(Name ="Mã hình ảnh")]
        public int ImgID { get; set; }
        [MaxLength(50)]
        [Display(Name ="Hình sản phẩm")]
        public string ProductImage { get; set; }
        [MaxLength(50)]
        [Display(Name = "Hình chi tiết sản phẩm")]
        public string SingleImage1 { get; set; }
        [MaxLength(50)]
        [Display(Name = "Hình chi tiết sản phẩm")]
        public string SingleImage2 { get; set; }
        [MaxLength(50)]
        [Display(Name = "Hình chi tiết sản phẩm")]
        public string SingleImage3 { get; set; }
        [MaxLength(50)]
        [Display(Name = "Hình chi tiết sản phẩm")]
        public string SingleImage4 { get; set; }

    }
}
