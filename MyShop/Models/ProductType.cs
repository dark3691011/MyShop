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
        [Display(Name ="Mã loại")]
        [Required]
        public int TypeID { get; set; }
        [MaxLength(100)]
        [Display(Name ="Tên loại")]
        [Required(ErrorMessage ="Chưa nhập tên loại")]
        public string TypeName { get; set; }
        

        [Display(Name ="Mã loại cha")]
        public int? FatherTypeID { get; set; }
        [ForeignKey("FatherTypeID")]
        public ProductType FatherProductType { get; set; }


        public string TypeNameSeoUrl => TypeName.ToUrlFriendly();
    }
}
