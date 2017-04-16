using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MvcMovie.Models.Identity;
namespace MvcMovie.Models.Identity
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Cart> Carts { get; set; }
        
        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails  { get; set; }

        //public DbSet<CartItem> CartItems { get; set; }
        //public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}