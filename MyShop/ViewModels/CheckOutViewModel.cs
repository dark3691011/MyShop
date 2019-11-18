using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.ViewModels
{
    public class CheckOutViewModel
    {
        [Display(Name = "Mã khách hàng")]
        public int CustomerID { get; set; }
        [Required(ErrorMessage = "Phải nhập tên")]
        [Display(Name = "Tên khách hàng")]
        [StringLength(70, MinimumLength = 9, ErrorMessage = "Tên từ 10 đến 70 kí tự")]
        public string Name { get; set; }
        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage ="Phải nhập địa chỉ")]
        [MaxLength(100)]
        public string Addres { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Số điện thoại")]
        [Required(ErrorMessage ="Phải nhập số điện thoại")]
        public string PhoneNumber { get; set; }
    }
}
