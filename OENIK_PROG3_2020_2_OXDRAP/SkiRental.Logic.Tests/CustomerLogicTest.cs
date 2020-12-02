// <copyright file="CustomerLogicTest.cs" company="OXDRAP">
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
    /// This is the test class for CustomerLogic.
    /// </summary>
    [TestFixture]
    public class CustomerLogicTest
    {
        private readonly Customer addtest = new Customer() { CustomerId = 4, FirstName = "Ken", LastName = "Cobbett", Password = "kencobbett098", Birthdate = new DateTime(1981, 04, 16), Difficulty = "pro", Email = "kencobbett@gmail.com", Postcode = 12842, Size = 190 };
        private List<Customer> customers;

        private CustomerLogic CustomerLogic { get; set; }

        private Mock<ICustomerRepository> MockedCustomerRepository { get; set; }

        /// <summary>
        /// This is the Setup for the tests.
        /// </summary>
        [OneTimeSetUp]
        public void Setup()
        {
            this.MockedCustomerRepository = new Mock<ICustomerRepository>(MockBehavior.Loose);
            this.CustomerLogic = new CustomerLogic(this.MockedCustomerRepository.Object);
            this.customers = new List<Customer>();

            this.customers.Add(new Customer() { CustomerId = 1, FirstName = "Louie", LastName = "Rogers", Password = "Louirog123", Birthdate = new DateTime(1988, 02, 17), Difficulty = "advanced", Email = "louierogers@gmail.com", Postcode = 12842, Size = 170 });
            this.customers.Add(new Customer() { CustomerId = 2, FirstName = "Theo", LastName = "Lee", Password = "Theolee.123", Birthdate = new DateTime(2001, 04, 06), Difficulty = "beginner", Email = "theolee@gmail.com", Postcode = 12847, Size = 170 });
            this.customers.Add(new Customer() { CustomerId = 3, FirstName = "Regina", LastName = "Mills", Password = "Remi22", Birthdate = new DateTime(1995, 02, 22), Difficulty = "advanced", Email = "reginamills@gmail.com", Postcode = 13360, Size = 160 });
        }

        /// <summary>
        /// Tests GetCustomerById method. This is a noncrud.
        /// </summary>
        /// <param name="id">Id.</param>
        [TestCase(0)]
        [TestCase(1)]
        public void TestGetCustomerByID(int id)
        {
            this.MockedCustomerRepository.Setup(repo => repo.GetOne(It.Is<int>(id => id >= 0 && id < this.customers.Count))).Returns(this.customers[id]);

            var result = this.CustomerLogic.GetCustomerById(id);

            this.MockedCustomerRepository.Verify(x => x.GetOne(id), Times.Exactly(1));
            this.MockedCustomerRepository.Verify(x => x.GetOne(50), Times.Never);
        }

        /// <summary>
        /// Tests GetAllCustomer method. This is a noncrud.
        /// </summary>
        [Test]
        public void TestGetAllCustomers()
        {
            this.MockedCustomerRepository.Setup(repo => repo.GetAll()).Returns(this.customers.AsQueryable());

            var result = this.CustomerLogic.GetAllCustomers();

            this.MockedCustomerRepository.Verify(x => x.GetAll(), Times.Once);
        }

        /// <summary>
        /// Tests Insert method. This is a noncrud.
        /// </summary>
        [Test]
        public void TestCreateCustomer()
        {
            this.MockedCustomerRepository.Setup(repo => repo.Insert(It.IsAny<Customer>()));

            this.CustomerLogic.CreateCustomer(this.addtest);

            this.MockedCustomerRepository.Verify(repo => repo.Insert(this.addtest), Times.Once);
        }

        /// <summary>
        /// Tests Update method. This is a noncrud.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <param name="newPassword">New password.</param>
        [TestCase(1, "newpassword")]
        public void TestUpdate(int id, string newPassword)
        {
            this.MockedCustomerRepository.Setup(repo => repo.ChangePassword(It.IsAny<int>(), It.IsAny<string>()));

            this.CustomerLogic.ChangePassword(id, newPassword);

            this.MockedCustomerRepository.Verify(repo => repo.ChangePassword(id, newPassword), Times.Once);
        }
    }
}
