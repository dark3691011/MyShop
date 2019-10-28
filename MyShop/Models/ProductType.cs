using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Models
{
    public class ProductType
    {
        [Key]
        [MaxLength(50)]
        [Display(Name ="Mã loại")]
        [Required]
        public int TypeID { get; set; }
        [MaxLength(100)]
        [Display(Name ="Tên loại")]
        public string TypeName { get; set; }
        

        [MaxLength(50)]
        [Display(Name ="Mã loại cha")]
        public int? FatherTypeID { get; set; }
        [ForeignKey("FatherTypeID")]
        public ProductType FatherProductType { get; set; }
    }
}
