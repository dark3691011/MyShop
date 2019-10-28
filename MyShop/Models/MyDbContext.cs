using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Models
{
    public class MyDbContext : DbContext
    {
        public DbSet<ProductType> productTypes { get; set; }
        public DbSet<Trademark> trademarks { get; set; }
        public DbSet<Discount> discounts { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Bill> bills { get; set; }
        public DbSet<BillDetail> billDetails { get; set; }
        public DbSet<Customer> customers { get; set; }

        public MyDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
