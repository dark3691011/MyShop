using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.DataModels
{
    public class Trademark
    {
        [Key]
        public int TrademarkID { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }
        public string Addres { get; set; }
    }
}
