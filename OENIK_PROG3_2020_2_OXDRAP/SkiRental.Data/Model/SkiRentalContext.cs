using Microsoft.EntityFrameworkCore;
using SkiRental.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkiRental.Data
{
    public class SkiRentalContext : DbContext
    {
        public SkiRentalContext()
        {
            this.Database.EnsureCreated();
        }

        public SkiRentalContext(DbContextOptions<SkiRentalContext> options) : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<SkiEquipments> SkiEquipments { get; set; }
        public virtual DbSet<Basket> Basket { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\SkiRentalDatabase.mdf;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
