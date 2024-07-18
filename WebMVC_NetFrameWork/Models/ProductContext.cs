using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebMVC_NetFrameWork.Models
{
    public class ProductContext : DbContext
    {

        public ProductContext() : base("name=ProductContext")
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}