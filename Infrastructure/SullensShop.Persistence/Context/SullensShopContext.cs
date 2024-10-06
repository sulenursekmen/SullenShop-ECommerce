using Microsoft.EntityFrameworkCore;
using SullensShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SullensShop.Persistence.Context
{
    public class SullensShopContext:DbContext
    {
        public SullensShopContext(DbContextOptions<SullensShopContext> options):base(options)
        { 

        }
       
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryDetail> CategoryDetails { get; set; }

    }
}
