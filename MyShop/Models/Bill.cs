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
        public int BillID { get; set; }
        public double TotalAmount { get; set; }
        public DateTime BillTime { get; set; }
        public string PaymentMethod { get; set; }
        public string Status { get; set; }

        public int CustomerID { get; set; }
        [ForeignKey("CustomerID")]
        public Customer Customer { get; set; }
    }
}
