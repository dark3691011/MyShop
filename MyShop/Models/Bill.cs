using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Models
{
    public class Bill
    {
        [Key]
        [Required]
        [Display(Name = "Mã hóa đơn")]
        public int BillID { get; set; }
        [Required(ErrorMessage ="Chưa có tổng tiền")]
        [Display(Name ="Tổng tiền")]
        public double TotalAmount { get; set; }
        [Display(Name ="Thời gian thanh toán")]
        [Required(ErrorMessage ="Chưa có thời gian")]
        public DateTime BillTime { get; set; }
        [Display(Name ="Phương thức thanh toán")]
        [MaxLength(50)]
        [Required(ErrorMessage ="Chưa có phương thức")]
        public string PaymentMethod { get; set; }
        [Display(Name ="Trạng thái")]
        [Required(ErrorMessage ="Chưa có trạng thái")]
        [MaxLength(20)]
        public string Status { get; set; }

        [Display(Name ="Mã khách hàng")]
        public int CustomerID { get; set; }
        [ForeignKey("CustomerID")]
        public Customer Customer { get; set; }
    }
}
