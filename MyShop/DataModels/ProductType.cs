using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.DataModels
{
    public class ProductType
    {
        [Key]
        public int TypeID { get; set; }
        public string TypeName { get; set; }
        public string Description { get; set; }


        public string FatherTypeID { get; set; }
        public ProductType FatherProductType { get; set; }
    }
}
