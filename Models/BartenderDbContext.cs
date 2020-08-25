using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bartender_App.Models;

namespace Bartender_App.Models
{
    public class BartenderDbContext : DbContext
    {
        public BartenderDbContext(DbContextOptions<BartenderDbContext> options)
            : base(options)
        {

        }

        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasData(
               new Order
               {
                   Id = 1,
                   OrderName = "Jacob",
                   DrinkOrdered = "Bourbon Old Fashioned",
                   Total = "$10.99",
                   Ready = false,
                   PickedUp = false
               });
        }
    }
}
