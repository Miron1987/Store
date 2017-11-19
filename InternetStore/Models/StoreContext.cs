
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace InternetStore.Models
{
    public class StoreContext : DbContext
    {

        public DbSet<Product> Products { get; set; }
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Categorie> Categories { get; set; }
 
    }

}