﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Phải nhập tên đăng nhập")]
        [Display(Name = "Tên đăng nhập")]
        [StringLength(30, MinimumLength = 9, ErrorMessage = "Tên đăng nhập từ 9 đến 30 kí tự")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Phải nhập mật khẩu")]
        [Display(Name = "Mật khẩu")]
        [DataType(DataType.Password)]
        [StringLength(30, MinimumLength = 7, ErrorMessage = "Mật khẩu từ 7 đến 30 kí tự")]
        public string Password { get; set; }
    }
}
