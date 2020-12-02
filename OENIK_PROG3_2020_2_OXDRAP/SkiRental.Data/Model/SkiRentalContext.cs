// <copyright file="SkiRentalContext.cs" company="OXDRAP">
// Copyright (c) OXDRAP. All rights reserved.
// </copyright>

namespace SkiRental.Data
{
    using System;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// This is the Context class of the database.
    /// </summary>
    public class SkiRentalContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SkiRentalContext"/> class.
        /// </summary>
        public SkiRentalContext()
        {
            this.Database.EnsureCreated();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SkiRentalContext"/> class.
        /// </summary>
        /// <param name="options">Options.</param>
        public SkiRentalContext(DbContextOptions<SkiRentalContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the Customers table.
        /// </summary>
        public virtual DbSet<Customer> Customers { get; set; }

        /// <summary>
        /// Gets or sets the Orders table.
        /// </summary>
        public virtual DbSet<Order> Orders { get; set; }

        /// <summary>
        /// Gets or sets the SkiEquipments table.
        /// </summary>
        public virtual DbSet<SkiEquipments> SkiEquipments { get; set; }

        /// <summary>
        /// Overrideing the original OnConfiguring method.
        /// </summary>
        /// <param name="optionsBuilder">Sets the connection for the database.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder != null)
            {
                if (!optionsBuilder.IsConfigured)
                {
                    optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\SkiRentalDatabase.mdf;Integrated Security=True");
                }
            }
        }

        /// <summary>
        /// Overriding the original OnModelCreating method. Creating instances and setting connections between the tables.
        /// </summary>
        /// <param name="modelBuilder">Modelbuilder instance.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Customer c0 = new Customer() { CustomerId = 1, FirstName = "Louie", LastName = "Rogers", Password = "Louirog123", Birthdate = new DateTime(1988, 02, 17), Difficulty = "advanced", Email = "louierogers@gmail.com", Postcode = 12842, Size = 170 };
            Customer c1 = new Customer() { CustomerId = 2, FirstName = "Theo", LastName = "Lee", Password = "Theolee.123", Birthdate = new DateTime(2001, 04, 06), Difficulty = "beginner", Email = "theolee@gmail.com", Postcode = 12847, Size = 170 };
            Customer c2 = new Customer() { CustomerId = 3, FirstName = "Regina", LastName = "Mills", Password = "Remi22", Birthdate = new DateTime(1995, 02, 22), Difficulty = "advanced", Email = "reginamills@gmail.com", Postcode = 13360, Size = 160 };
            Customer c3 = new Customer() { CustomerId = 4, FirstName = "Ken", LastName = "Cobbett", Password = "kencobbett098", Birthdate = new DateTime(1981, 04, 16), Difficulty = "pro", Email = "kencobbett@gmail.com", Postcode = 12842, Size = 190 };
            Customer c4 = new Customer() { CustomerId = 5, FirstName = "Camelia", LastName = "Davison", Password = "Camelia0112", Birthdate = new DateTime(1999, 03, 28), Difficulty = "beginner", Email = "camelia0328@gmail.com", Postcode = 12139, Size = 170 };
            Customer c5 = new Customer() { CustomerId = 6, FirstName = "Atwater", LastName = "Brown", Password = "atwaterBrown", Birthdate = new DateTime(2000, 03, 26), Difficulty = "pro", Email = "atwaterb@gmail.com", Postcode = 13353, Size = 180 };
            Customer c6 = new Customer() { CustomerId = 7, FirstName = "Calvin", LastName = "Warner", Password = "Calvin12345", Birthdate = new DateTime(2000, 07, 11), Difficulty = "advanced", Email = "calvinwarner@gmail.com", Postcode = 12190, Size = 190 };
            Customer c7 = new Customer() { CustomerId = 8, FirstName = "Eva", LastName = "Austin", Password = "EvaAustin45", Birthdate = new DateTime(2001, 09, 06), Difficulty = "pro", Email = "evaustin@gmail.com", Postcode = 12108, Size = 160 };
            Customer c8 = new Customer() { CustomerId = 9, FirstName = "Jasmine", LastName = "Taylor", Password = "jasminetay111", Birthdate = new DateTime(2005, 06, 28), Difficulty = "beginner", Email = "jasminetaylor@gmail.com", Postcode = 12842, Size = 170 };

            Order o0 = new Order() { OrderId = 1, FirstDate = new DateTime(2018, 11, 16), LastDate = new DateTime(2018, 11, 19), Payment = "Credit Card", Promotion = 20, CustomerPaid = true };
            Order o1 = new Order() { OrderId = 2, FirstDate = new DateTime(2018, 11, 29), LastDate = new DateTime(2018, 12, 04), Payment = "Credit Card", Promotion = null, CustomerPaid = true };
            Order o2 = new Order() { OrderId = 3, FirstDate = new DateTime(2018, 12, 04), LastDate = new DateTime(2018, 12, 04), Payment = "PayPal", Promotion = 25, CustomerPaid = true };
            Order o3 = new Order() { OrderId = 4, FirstDate = new DateTime(2018, 12, 19), LastDate = new DateTime(2018, 12, 22), Payment = "Credit Card", Promotion = null, CustomerPaid = false };
            Order o4 = new Order() { OrderId = 5, FirstDate = new DateTime(2018, 12, 31), LastDate = new DateTime(2018, 01, 06), Payment = "Credit Card", Promotion = 15, CustomerPaid = true };
            Order o5 = new Order() { OrderId = 6, FirstDate = new DateTime(2019, 01, 14), LastDate = new DateTime(2019, 01, 18), Payment = "PayPal", Promotion = 20, CustomerPaid = false };
            Order o6 = new Order() { OrderId = 7, FirstDate = new DateTime(2019, 02, 13), LastDate = new DateTime(2019, 02, 19), Payment = "Credit Card", Promotion = null, CustomerPaid = true };
            Order o7 = new Order() { OrderId = 8, FirstDate = new DateTime(2019, 03, 03), LastDate = new DateTime(2019, 03, 08), Payment = "Credit Card", Promotion = null, CustomerPaid = true };
            Order o8 = new Order() { OrderId = 9, FirstDate = new DateTime(2019, 03, 07), LastDate = new DateTime(2019, 03, 10), Payment = "PayPal", Promotion = null, CustomerPaid = true };
            Order o9 = new Order() { OrderId = 10, FirstDate = new DateTime(2019, 03, 23), LastDate = new DateTime(2019, 03, 27), Payment = "Credit Card", Promotion = null, CustomerPaid = true };

            SkiEquipments s00 = new SkiEquipments() { SkiEquipmentsId = 1, Name = "Supershape", Manufacturer = "Head", Difficulty = "pro", Price = 500, Size = 160, Status = true };
            SkiEquipments s02 = new SkiEquipments() { SkiEquipmentsId = 2, Name = "Supershape", Manufacturer = "Head", Difficulty = "pro", Price = 500, Size = 180, Status = true };
            SkiEquipments s03 = new SkiEquipments() { SkiEquipmentsId = 3, Name = "Supershape", Manufacturer = "Head", Difficulty = "pro", Price = 500, Size = 190, Status = false };
            SkiEquipments s11 = new SkiEquipments() { SkiEquipmentsId = 4, Name = "Redster", Manufacturer = "Atomic", Difficulty = "beginner", Price = 100, Size = 170, Status = false };
            SkiEquipments s20 = new SkiEquipments() { SkiEquipmentsId = 5, Name = "React R4", Manufacturer = "Rossignol", Difficulty = "advanced", Price = 250, Size = 160, Status = true };
            SkiEquipments s21 = new SkiEquipments() { SkiEquipmentsId = 6, Name = "React R4", Manufacturer = "Rossignol", Difficulty = "advanced", Price = 250, Size = 170, Status = false };
            SkiEquipments s23 = new SkiEquipments() { SkiEquipmentsId = 7, Name = "React R4", Manufacturer = "Rossignol", Difficulty = "advanced", Price = 250, Size = 190, Status = false };

            o4.CustomerId = c0.CustomerId;
            o7.CustomerId = c1.CustomerId;
            o5.CustomerId = c2.CustomerId;
            o0.CustomerId = c3.CustomerId;
            o9.CustomerId = c3.CustomerId;
            o6.CustomerId = c4.CustomerId;
            o2.CustomerId = c5.CustomerId;
            o8.CustomerId = c6.CustomerId;
            o1.CustomerId = c7.CustomerId;
            o3.CustomerId = c8.CustomerId;

            s21.OrderId = o4.OrderId;
            s20.OrderId = o5.OrderId;
            s03.OrderId = o9.OrderId;
            s02.OrderId = o2.OrderId;
            s23.OrderId = o8.OrderId;
            s00.OrderId = o1.OrderId;
            s11.OrderId = o3.OrderId;

            if (modelBuilder == null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }
            else
            {
                modelBuilder.Entity<Customer>(entity =>
                {
                entity.HasMany(c => c.Orders)
                .WithOne(o => o.Customer)
                .HasForeignKey(c => c.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);
                });

                modelBuilder.Entity<SkiEquipments>(entity =>
                {
                    entity.HasOne(s => s.Order)
                    .WithMany(b => b.SkiEquipments)
                    .HasForeignKey(o => o.OrderId)
                    .OnDelete(DeleteBehavior.Cascade);
                });

                modelBuilder.Entity<Order>(entity =>
                {
                    entity.HasOne(o => o.Customer)
                    .WithMany(c => c.Orders)
                    .HasForeignKey(o => o.CustomerId);

                    entity.HasMany(o => o.SkiEquipments)
                    .WithOne(s => s.Order)
                    .HasForeignKey(o => o.OrderId);
                });

                modelBuilder.Entity<Customer>().HasData(c0, c1, c2, c3, c4, c5, c6, c7, c8);
                modelBuilder.Entity<Order>().HasData(o0, o1, o2, o3, o4, o5, o6, o7, o8, o9);
                modelBuilder.Entity<SkiEquipments>().HasData(s00, s02, s03, s11, s20, s21, s23);
            }
        }
    }
}
