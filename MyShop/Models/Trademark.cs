using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Models
{
    public class Trademark
    {
        [Key]
        [Display(Name ="Mã thương hiệu")]
        [Required]
        public int TrademarkID { get; set; }
        [Display(Name="Tên thương hiệu")]
        [MaxLength(50)]
        [Required(ErrorMessage ="Phải nhập tên thương hiệu")]
        public string Name { get; set; }
        [MaxLength(255)]
        [Display(Name ="Mô tả")]
        public string Description { get; set; }
        [MaxLength(150)]
        [Display(Name="Logo thương hiệu")]
        public string Logo { get; set; }
        [MaxLength(150)]
        [Display(Name="Địa chỉ")]
        public string Addres { get; set; }
    }
}
