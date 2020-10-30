namespace SkiRental.Data
{
    using System;
    using Microsoft.EntityFrameworkCore;

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
        /// <param name="options"></param>
        public SkiRentalContext(DbContextOptions<SkiRentalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<SkiEquipments> SkiEquipments { get; set; }

        public virtual DbSet<Basket> Basket { get; set; }

        /// <inheritdoc/>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\SkiRentalDatabase.mdf;Integrated Security=True");
            }
        }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Customer c0 = new Customer() { CustomerId = 0, FirstName = "Louie", LastName = "Rogers", Password = "Louirog123", Birthdate = new DateTime(1988, 02, 17), Difficulty = "advanced", Email = "louierogers@gmail.com", Postcode = 12842, Size = 170 };
            Customer c1 = new Customer() { CustomerId = 1, FirstName = "Theo", LastName = "Lee", Password = "Theolee.123", Birthdate = new DateTime(2001, 04, 06), Difficulty = "beginner", Email = "theolee@gmail.com", Postcode = 12847, Size = 170 };
            Customer c2 = new Customer() { CustomerId = 2, FirstName = "Regina", LastName = "Mills", Password = "Remi22", Birthdate = new DateTime(1995, 02, 22), Difficulty = "advanced", Email = "reginamills@gmail.com", Postcode = 13360, Size = 160 };
            Customer c3 = new Customer() { CustomerId = 3, FirstName = "Ken", LastName = "Cobbett", Password = "kencobbett098", Birthdate = new DateTime(1981, 04, 16), Difficulty = "pro", Email = "kencobbett@gmail.com", Postcode = 12842, Size = 190 };
            Customer c4 = new Customer() { CustomerId = 4, FirstName = "Camelia", LastName = "Davison", Password = "Camelia0112", Birthdate = new DateTime(1999, 03, 28), Difficulty = "beginner", Email = "camelia0328@gmail.com", Postcode = 12139, Size = 170 };
            Customer c5 = new Customer() { CustomerId = 5, FirstName = "Atwater", LastName = "Brown", Password = "atwaterBrown", Birthdate = new DateTime(2000, 03, 26), Difficulty = "pro", Email = "atwaterb@gmail.com", Postcode = 13353, Size = 180 };
            Customer c6 = new Customer() { CustomerId = 6, FirstName = "Calvin", LastName = "Warner", Password = "Calvin12345", Birthdate = new DateTime(2000, 07, 11), Difficulty = "advanced", Email = "calvinwarner@gmail.com", Postcode = 12190, Size = 190 };
            Customer c7 = new Customer() { CustomerId = 7, FirstName = "Eva", LastName = "Austin", Password = "EvaAustin45", Birthdate = new DateTime(2001, 09, 06), Difficulty = "pro", Email = "evaustin@gmail.com", Postcode = 12108, Size = 160 };
            Customer c8 = new Customer() { CustomerId = 8, FirstName = "Jasmine", LastName = "Taylor", Password = "jasminetay111", Birthdate = new DateTime(2005, 06, 28), Difficulty = "beginner", Email = "jasminetaylor@gmail.com", Postcode = 12842, Size = 170 };

            Order o0 = new Order() { OrderId = 0, FirstDate = new DateTime(2018, 11, 16), LastDate = new DateTime(2018, 11, 19), Payment = "Credit Card", Promotion = 20, CustomerPaid = true };
            Order o1 = new Order() { OrderId = 1, FirstDate = new DateTime(2018, 11, 29), LastDate = new DateTime(2018, 12, 04), Payment = "Credit Card", Promotion = null, CustomerPaid = true };
            Order o2 = new Order() { OrderId = 2, FirstDate = new DateTime(2018, 12, 04), LastDate = new DateTime(2018, 12, 04), Payment = "PayPal", Promotion = 25, CustomerPaid = true };
            Order o3 = new Order() { OrderId = 3, FirstDate = new DateTime(2018, 12, 19), LastDate = new DateTime(2018, 12, 22), Payment = "Credit Card", Promotion = null, CustomerPaid = false };
            Order o4 = new Order() { OrderId = 4, FirstDate = new DateTime(2018, 12, 31), LastDate = new DateTime(2018, 01, 06), Payment = "Credit Card", Promotion = 15, CustomerPaid = true };
            Order o5 = new Order() { OrderId = 5, FirstDate = new DateTime(2019, 01, 14), LastDate = new DateTime(2019, 01, 18), Payment = "PayPal", Promotion = 20, CustomerPaid = false };
            Order o6 = new Order() { OrderId = 6, FirstDate = new DateTime(2019, 02, 13), LastDate = new DateTime(2019, 02, 19), Payment = "Credit Card", Promotion = null, CustomerPaid = true };
            Order o7 = new Order() { OrderId = 7, FirstDate = new DateTime(2019, 03, 03), LastDate = new DateTime(2019, 03, 08), Payment = "Credit Card", Promotion = null, CustomerPaid = true };
            Order o8 = new Order() { OrderId = 8, FirstDate = new DateTime(2019, 03, 07), LastDate = new DateTime(2019, 03, 10), Payment = "PayPal", Promotion = null, CustomerPaid = true };
            Order o9 = new Order() { OrderId = 9, FirstDate = new DateTime(2019, 03, 23), LastDate = new DateTime(2019, 03, 27), Payment = "Credit Card", Promotion = null, CustomerPaid = true };

            SkiEquipments s00 = new SkiEquipments() { SkiEquipmentsId = 0, Name = "Supershape", Manufacturer = "Head", Difficulty = "pro", Price = 500, Size = 160, Status = true };
            SkiEquipments s01 = new SkiEquipments() { SkiEquipmentsId = 1, Name = "Supershape", Manufacturer = "Head", Difficulty = "pro", Price = 500, Size = 170, Status = true };
            SkiEquipments s02 = new SkiEquipments() { SkiEquipmentsId = 2, Name = "Supershape", Manufacturer = "Head", Difficulty = "pro", Price = 500, Size = 180, Status = true };
            SkiEquipments s03 = new SkiEquipments() { SkiEquipmentsId = 3, Name = "Supershape", Manufacturer = "Head", Difficulty = "pro", Price = 500, Size = 190, Status = false };

            SkiEquipments s10 = new SkiEquipments() { SkiEquipmentsId = 4, Name = "Redster", Manufacturer = "Atomic", Difficulty = "beginner", Price = 100, Size = 160, Status = true };
            SkiEquipments s11 = new SkiEquipments() { SkiEquipmentsId = 5, Name = "Redster", Manufacturer = "Atomic", Difficulty = "beginner", Price = 100, Size = 170, Status = false };
            SkiEquipments s12 = new SkiEquipments() { SkiEquipmentsId = 6, Name = "Redster", Manufacturer = "Atomic", Difficulty = "beginner", Price = 100, Size = 180, Status = false };
            SkiEquipments s13 = new SkiEquipments() { SkiEquipmentsId = 7, Name = "Redster", Manufacturer = "Atomic", Difficulty = "beginner", Price = 100, Size = 190, Status = true };

            SkiEquipments s20 = new SkiEquipments() { SkiEquipmentsId = 8, Name = "React R4", Manufacturer = "Rossignol", Difficulty = "advanced", Price = 250, Size = 160, Status = true };
            SkiEquipments s21 = new SkiEquipments() { SkiEquipmentsId = 9, Name = "React R4", Manufacturer = "Rossignol", Difficulty = "advanced", Price = 250, Size = 170, Status = false };
            SkiEquipments s22 = new SkiEquipments() { SkiEquipmentsId = 10, Name = "React R4", Manufacturer = "Rossignol", Difficulty = "advanced", Price = 250, Size = 180, Status = false };
            SkiEquipments s23 = new SkiEquipments() { SkiEquipmentsId = 11, Name = "React R4", Manufacturer = "Rossignol", Difficulty = "advanced", Price = 250, Size = 190, Status = false };

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

            Basket b0 = new Basket() { BasketId = 0, OrderId = 4, SkiEquipmentsId = 9 };
            Basket b1 = new Basket() { BasketId = 1, OrderId = 7, SkiEquipmentsId = 5 };
            Basket b2 = new Basket() { BasketId = 2, OrderId = 5, SkiEquipmentsId = 8 };
            Basket b3 = new Basket() { BasketId = 3, OrderId = 0, SkiEquipmentsId = 3 };
            Basket b4 = new Basket() { BasketId = 4, OrderId = 9, SkiEquipmentsId = 3 };
            Basket b5 = new Basket() { BasketId = 5, OrderId = 6, SkiEquipmentsId = 5 };
            Basket b6 = new Basket() { BasketId = 6, OrderId = 2, SkiEquipmentsId = 2 };
            Basket b7 = new Basket() { BasketId = 7, OrderId = 8, SkiEquipmentsId = 11 };
            Basket b8 = new Basket() { BasketId = 8, OrderId = 1, SkiEquipmentsId = 0 };
            Basket b9 = new Basket() { BasketId = 9, OrderId = 3, SkiEquipmentsId = 5 };

            _ = modelBuilder.Entity<Customer>(entity =>
              {
                  entity.HasMany(c => c.Orders)
                  .WithOne(o => o.Customer)
                  .HasForeignKey(c => c.CustomerId)
                  .OnDelete(DeleteBehavior.Cascade);

              });

            modelBuilder.Entity<Basket>(entity =>
            {
                entity.HasMany(b => b.SkiEquipment)
                .WithOne(s => s.Basket)
                .HasForeignKey(b => b.BasketId)
                .OnDelete(DeleteBehavior.Cascade);

            });

            modelBuilder.Entity<SkiEquipments>(entity =>
            {
                entity.HasOne(s => s.Basket)
                .WithMany(b => b.SkiEquipment)
                .HasForeignKey(o => o.BasketId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasOne(o => o.Basket)
                .WithOne(b => b.Order)
                .HasForeignKey<Order>(o => o.BasketId);

                entity.HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId);
            });

            modelBuilder.Entity<Customer>().HasData(c0, c1, c2, c3, c4, c5, c6, c7, c8);
            modelBuilder.Entity<Order>().HasData(o0, o1, o2, o3, o4, o5, o6, o7, o8, o9);
            modelBuilder.Entity<SkiEquipments>().HasData(s00, s01, s02, s03, s10, s11, s12, s13, s20, s21, s22, s23);
            modelBuilder.Entity<Basket>().HasData(b0, b1, b2, b3, b4, b5, b6, b7, b8, b9);
        }
    }
}
