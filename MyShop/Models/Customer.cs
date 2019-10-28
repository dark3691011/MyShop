using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Models
{
    public class Customer
    {
        [Key]
        [Required]
        [Display(Name="Mã khách hàng")]
        public int CustomerID { get; set; }
        [Required(ErrorMessage ="Phải nhập tên")]
        [Display(Name="Tên khách hàng")]
        [MaxLength(150)]
        public string Name { get; set; }
        [Required(ErrorMessage ="Phải nhập tên đăng nhập")]
        [Display(Name="Tên đăng nhập")]
        [MaxLength(30)]
        public string UserName { get; set; }
        [Required(ErrorMessage ="Phải nhập mật khẩu")]
        [Display(Name = "Mật khẩu")]
        [MaxLength(30)]
        public string Password { get; set; }
        [Display(Name = "Ngày sinh")]
        public DateTime DateOfBirth { get; set; }
        [Display(Name ="Giới tính")]
        [Required(ErrorMessage ="Chưa có giới tính")]
        public int Gender { get; set; }
        [Display(Name = "Địa chỉ")]
        [MaxLength(100)]
        public string Addres { get; set; }
    }
}
