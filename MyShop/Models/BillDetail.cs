using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Models
{
    public class BillDetail
    {
        [Key]
        [Required]
        [Display(Name ="Mã chi tiết hóa đơn")]
        public int BillDetailID { get; set; }
        [Required(ErrorMessage ="Chưa có tổng tiền")]
        [Display(Name ="Tổng tiền")]
        public int Amount { get; set; }

        [Display(Name ="Mã hóa đơn")]
        public int ProductID { get; set; }
        [ForeignKey("ProductID")]
        public Product Product { get; set; }
    }
}
