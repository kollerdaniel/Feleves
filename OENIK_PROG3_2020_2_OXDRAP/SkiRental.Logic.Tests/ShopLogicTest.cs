// <copyright file="ShopLogicTest.cs" company="OXDRAP">
// Copyright (c) OXDRAP. All rights reserved.
// </copyright>

namespace SkiRental.Logic.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Moq;
    using NUnit.Framework;
    using SkiRental.Data;
    using SkiRental.Repository;

    /// <summary>
    /// This is the test class for the ShopLogic.
    /// </summary>
    [TestFixture]
    public class ShopLogicTest
    {
        private List<Order> orders;

        private List<SkiEquipments> skiEquipments;

        private List<Customer> customers;

        private ShopLogic ShopLogic { get; set; }

        private Mock<IOrderRepository> MockedOrderRepository { get; set; }

        private Mock<ISkiEquipmentsRepository> MockedSkiEquipmentsRepository { get; set; }

        private Mock<ICustomerRepository> MockedCustomerRepo { get; set; }

        /// <summary>
        /// Tests the PromotinOver170 method. This is a noncrud.
        /// </summary>
        [Test]
        public void TestPromotionOver170()
        {
            this.ShopLogicWithMocks();
            List<PromotionResult> expectedResult = new List<PromotionResult>()
            {
                new PromotionResult() { Size = 180, Promotion = 25 },
            };

            var actualResult = this.ShopLogic.PromotionOver170();

            Assert.That(actualResult, Is.EqualTo(expectedResult));
            this.MockedOrderRepository.Verify(repo => repo.GetAll(), Times.Once);
            this.MockedSkiEquipmentsRepository.Verify(repo => repo.GetAll(), Times.Once);
        }

        /// <summary>
        /// Tests the PromotinOver170 method with fake data. This is a noncrud.
        /// </summary>
        [Test]
        public void TestPromotionOver170Bad()
        {
            this.ShopLogicWithMocks();
            List<PromotionResult> expectedResult = new List<PromotionResult>()
            {
                new PromotionResult() { Size = 183, Promotion = 25 },
            };

            var actualResult = this.ShopLogic.PromotionOver170();

            Assert.That(actualResult, Is.Not.EqualTo(expectedResult));
            this.MockedOrderRepository.Verify(repo => repo.GetAll(), Times.Once);
            this.MockedSkiEquipmentsRepository.Verify(repo => repo.GetAll(), Times.Once);
        }

        /// <summary>
        /// Tests the PromotinOver170 method. This is a noncrud.
        /// </summary>
        [Test]
        public void TestPaidHead()
        {
            this.ShopLogicWithMocks();

            List<PaidResult> expectedResult = new List<PaidResult>()
            {
                new PaidResult() { Name = "Supershape", Manufacturer = "Head", Size = 160 },
                new PaidResult() { Name = "Supershape", Manufacturer = "Head", Size = 180 },
                new PaidResult() { Name = "Supershape", Manufacturer = "Head", Size = 190 },
            };

            var actualResult = this.ShopLogic.PaidHead();

            Assert.That(actualResult, Is.EqualTo(expectedResult));
            this.MockedOrderRepository.Verify(repo => repo.GetAll(), Times.Once);
            this.MockedSkiEquipmentsRepository.Verify(repo => repo.GetAll(), Times.Once);
        }

        /// <summary>
        /// Tests the BeginnersWithCreditCard method. This is a noncrud.
        /// </summary>
        [Test]
        public void TestBeginnersWithCreditCard()
        {
            this.ShopLogicWithMocks();

            List<BeginnersResult> expectedResult = new List<BeginnersResult>()
            {
                new BeginnersResult() { Name = "Jasmine Taylor", Diff = "beginner", Payment = "Credit Card" },
                new BeginnersResult() { Name = "Camelia Davison", Diff = "beginner", Payment = "Credit Card" },
                new BeginnersResult() { Name = "Theo Lee", Diff = "beginner", Payment = "Credit Card" },
            };

            var actualResult = this.ShopLogic.BeginnersWithCreditCard();

            Assert.That(actualResult, Is.EqualTo(expectedResult));
            this.MockedOrderRepository.Verify(repo => repo.GetAll(), Times.Once);
            this.MockedSkiEquipmentsRepository.Verify(repo => repo.GetAll(), Times.Never);
        }

        /// <summary>
        /// Tests DeleteOrder method. This is a crud.
        /// </summary>
        /// <param name="id">Id.</param>
        [TestCase(1)]
        [TestCase(8)]
        public void TestDeleteOrder(int id)
        {
            this.ShopLogicWithMocks();

            this.MockedOrderRepository.Setup(repo => repo.Remove(It.IsAny<int>()));

            this.ShopLogic.DeleteOrder(id);

            this.MockedOrderRepository.Verify(repo => repo.Remove(id), Times.Once);
        }

        /// <summary>
        /// Tests GetOrderById method. This is a crud.
        /// </summary>
        /// <param name="id">Id.</param>
        [TestCase(3)]
        public void TestGetOneOrder(int id)
        {
            this.ShopLogicWithMocks();

            this.MockedOrderRepository.Setup(repo => repo.GetOne(It.Is<int>(id => id >= 0 && id < this.orders.Count))).Returns(this.orders[id]);

            var result = this.ShopLogic.GetOrderById(id);

            this.MockedOrderRepository.Verify(x => x.GetOne(id), Times.Exactly(1));
            this.MockedOrderRepository.Verify(x => x.GetOne(50), Times.Never);
        }

        /// <summary>
        /// Tests GetAllSkiEquipments method. This is a crud.
        /// </summary>
        [Test]
        public void TestGetAllSkiEquipments()
        {
            this.ShopLogicWithMocks();

            var result = this.ShopLogic.GetAllSkiEquipments();

            this.MockedSkiEquipmentsRepository.Verify(x => x.GetAll(), Times.Once);
        }

        /// <summary>
        /// This is the Setup for the ShopLogic tests.
        /// </summary>
        [SetUp]
        public void ShopLogicWithMocks()
        {
            this.MockedOrderRepository = new Mock<IOrderRepository>(MockBehavior.Loose);
            this.MockedSkiEquipmentsRepository = new Mock<ISkiEquipmentsRepository>(MockBehavior.Loose);
            this.MockedCustomerRepo = new Mock<ICustomerRepository>(MockBehavior.Loose);
            this.orders = new List<Order>();
            this.skiEquipments = new List<SkiEquipments>();

            this.customers = new List<Customer>()
            {
                new Customer() { CustomerId = 1, FirstName = "Louie", LastName = "Rogers", Password = "Louirog123", Birthdate = new DateTime(1988, 02, 17), Difficulty = "advanced", Email = "louierogers@gmail.com", Postcode = 12842, Size = 170 },
                new Customer() { CustomerId = 2, FirstName = "Theo", LastName = "Lee", Password = "Theolee.123", Birthdate = new DateTime(2001, 04, 06), Difficulty = "beginner", Email = "theolee@gmail.com", Postcode = 12847, Size = 170 },
                new Customer() { CustomerId = 3, FirstName = "Regina", LastName = "Mills", Password = "Remi22", Birthdate = new DateTime(1995, 02, 22), Difficulty = "advanced", Email = "reginamills@gmail.com", Postcode = 13360, Size = 160 },
                new Customer() { CustomerId = 4, FirstName = "Ken", LastName = "Cobbett", Password = "kencobbett098", Birthdate = new DateTime(1981, 04, 16), Difficulty = "pro", Email = "kencobbett@gmail.com", Postcode = 12842, Size = 190 },
                new Customer() { CustomerId = 5, FirstName = "Camelia", LastName = "Davison", Password = "Camelia0112", Birthdate = new DateTime(1999, 03, 28), Difficulty = "beginner", Email = "camelia0328@gmail.com", Postcode = 12139, Size = 170 },
                new Customer() { CustomerId = 6, FirstName = "Atwater", LastName = "Brown", Password = "atwaterBrown", Birthdate = new DateTime(2000, 03, 26), Difficulty = "pro", Email = "atwaterb@gmail.com", Postcode = 13353, Size = 180 },
                new Customer() { CustomerId = 7, FirstName = "Calvin", LastName = "Warner", Password = "Calvin12345", Birthdate = new DateTime(2000, 07, 11), Difficulty = "advanced", Email = "calvinwarner@gmail.com", Postcode = 12190, Size = 190 },
                new Customer() { CustomerId = 8, FirstName = "Eva", LastName = "Austin", Password = "EvaAustin45", Birthdate = new DateTime(2001, 09, 06), Difficulty = "pro", Email = "evaustin@gmail.com", Postcode = 12108, Size = 160 },
                new Customer() { CustomerId = 9, FirstName = "Jasmine", LastName = "Taylor", Password = "jasminetay111", Birthdate = new DateTime(2005, 06, 28), Difficulty = "beginner", Email = "jasminetaylor@gmail.com", Postcode = 12842, Size = 170 },
            };

            this.orders.Add(new Order() { OrderId = 1, FirstDate = new DateTime(2018, 11, 16), LastDate = new DateTime(2018, 11, 19), Payment = "Credit Card", Promotion = 20, CustomerPaid = true, CustomerId = 4, Customer = this.customers[3] });
            this.orders.Add(new Order() { OrderId = 2, FirstDate = new DateTime(2018, 11, 29), LastDate = new DateTime(2018, 12, 04), Payment = "Credit Card", Promotion = null, CustomerPaid = true, CustomerId = 8, Customer = this.customers[7] });
            this.orders.Add(new Order() { OrderId = 3, FirstDate = new DateTime(2018, 12, 04), LastDate = new DateTime(2018, 12, 04), Payment = "PayPal", Promotion = 25, CustomerPaid = true, CustomerId = 6, Customer = this.customers[5] });
            this.orders.Add(new Order() { OrderId = 4, FirstDate = new DateTime(2018, 12, 19), LastDate = new DateTime(2018, 12, 22), Payment = "Credit Card", Promotion = null, CustomerPaid = false, CustomerId = 9, Customer = this.customers[8] });
            this.orders.Add(new Order() { OrderId = 5, FirstDate = new DateTime(2018, 12, 31), LastDate = new DateTime(2018, 01, 06), Payment = "Credit Card", Promotion = 15, CustomerPaid = true, CustomerId = 1, Customer = this.customers[0] });
            this.orders.Add(new Order() { OrderId = 6, FirstDate = new DateTime(2019, 01, 14), LastDate = new DateTime(2019, 01, 18), Payment = "PayPal", Promotion = 20, CustomerPaid = false, CustomerId = 3, Customer = this.customers[2] });
            this.orders.Add(new Order() { OrderId = 7, FirstDate = new DateTime(2019, 02, 13), LastDate = new DateTime(2019, 02, 19), Payment = "Credit Card", Promotion = null, CustomerPaid = true, CustomerId = 5, Customer = this.customers[4] });
            this.orders.Add(new Order() { OrderId = 8, FirstDate = new DateTime(2019, 03, 03), LastDate = new DateTime(2019, 03, 08), Payment = "Credit Card", Promotion = null, CustomerPaid = true, CustomerId = 2, Customer = this.customers[1] });
            this.orders.Add(new Order() { OrderId = 9, FirstDate = new DateTime(2019, 03, 07), LastDate = new DateTime(2019, 03, 10), Payment = "PayPal", Promotion = null, CustomerPaid = true, CustomerId = 7, Customer = this.customers[6] });
            this.orders.Add(new Order() { OrderId = 10, FirstDate = new DateTime(2019, 03, 23), LastDate = new DateTime(2019, 03, 27), Payment = "Credit Card", Promotion = null, CustomerPaid = true, CustomerId = 4, Customer = this.customers[3] });

            this.skiEquipments.Add(new SkiEquipments() { SkiEquipmentsId = 1, Name = "Supershape", Manufacturer = "Head", Difficulty = "pro", Price = 500, Size = 160, Status = true, OrderId = 2, Order = this.orders[1] });
            this.skiEquipments.Add(new SkiEquipments() { SkiEquipmentsId = 2, Name = "Supershape", Manufacturer = "Head", Difficulty = "pro", Price = 500, Size = 180, Status = true, OrderId = 3, Order = this.orders[2] });
            this.skiEquipments.Add(new SkiEquipments() { SkiEquipmentsId = 3, Name = "Supershape", Manufacturer = "Head", Difficulty = "pro", Price = 500, Size = 190, Status = false, OrderId = 10, Order = this.orders[9] });
            this.skiEquipments.Add(new SkiEquipments() { SkiEquipmentsId = 4, Name = "Redster", Manufacturer = "Atomic", Difficulty = "beginner", Price = 100, Size = 170, Status = false, OrderId = 4, Order = this.orders[3] });
            this.skiEquipments.Add(new SkiEquipments() { SkiEquipmentsId = 5, Name = "React R4", Manufacturer = "Rossignol", Difficulty = "advanced", Price = 250, Size = 160, Status = true, OrderId = 6, Order = this.orders[5] });
            this.skiEquipments.Add(new SkiEquipments() { SkiEquipmentsId = 6, Name = "React R4", Manufacturer = "Rossignol", Difficulty = "advanced", Price = 250, Size = 170, Status = false, OrderId = 5, Order = this.orders[4] });
            this.skiEquipments.Add(new SkiEquipments() { SkiEquipmentsId = 7, Name = "React R4", Manufacturer = "Rossignol", Difficulty = "advanced", Price = 250, Size = 190, Status = false, OrderId = 9, Order = this.orders[8] });

            this.MockedCustomerRepo.Setup(repo => repo.GetAll()).Returns(this.customers.AsQueryable());
            this.MockedOrderRepository.Setup(repo => repo.GetAll()).Returns(this.orders.AsQueryable());
            this.MockedSkiEquipmentsRepository.Setup(repo => repo.GetAll()).Returns(this.skiEquipments.AsQueryable());
            this.ShopLogic = new ShopLogic(this.MockedOrderRepository.Object, this.MockedSkiEquipmentsRepository.Object);
        }
    }
}
