using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.DataModels
{
    public class ImgProduct
    {
        [Key]
        public int ImgID { get; set; }
        public string ProductImage { get; set; }
        public string SingleImage1 { get; set; }
        public string SingleImage2 { get; set; }
        public string SingleImage3 { get; set; }
        public string SingleImage4 { get; set; }

    }
}
