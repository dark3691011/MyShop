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
        [StringLength(70, MinimumLength = 10, ErrorMessage = "Tên từ 10 đến 70 kí tự")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Phải nhập tên đăng nhập")]
        [Display(Name="Tên đăng nhập")]
        [StringLength(30, MinimumLength = 10, ErrorMessage = "Tên đăng nhập từ 10 đến 30 kí tự")]
        public string UserName { get; set; }
        [Required(ErrorMessage ="Phải nhập mật khẩu")]
        [Display(Name = "Mật khẩu")]
        [DataType(DataType.Password)]
        [StringLength(30, MinimumLength = 10, ErrorMessage = "Mật khẩu từ 10 đến 30 kí tự")]
        public string Password { get; set; }
        [Required(ErrorMessage ="Phải nhập Email")]
        [DataType(DataType.EmailAddress)]
        [MaxLength(150)]
        public string Email { get; set; }
        [Display(Name = "Ngày sinh")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [Display(Name ="Giới tính")]
        [Required(ErrorMessage ="Chưa có giới tính")]
        public string Gender { get; set; }
        [Display(Name = "Địa chỉ")]
        [MaxLength(100)]
        public string Addres { get; set; }
    }
}
