using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.DataModels
{
    public class Bill
    {
        [Key]
        public int BillID { get; set; }
        public double TotalAmount { get; set; }
        public DateTime BillTime { get; set; }
    }
}
