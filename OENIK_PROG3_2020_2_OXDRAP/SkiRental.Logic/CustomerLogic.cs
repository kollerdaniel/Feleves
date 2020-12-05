// <copyright file="CustomerLogic.cs" company="OXDRAP">
// Copyright (c) OXDRAP. All rights reserved.
// </copyright>

namespace SkiRental.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SkiRental.Data;
    using SkiRental.Repository;

    /// <summary>
    /// This is the logic class of the Customers.
    /// </summary>
    public class CustomerLogic : ICustomerLogic
    {
        private ICustomerRepository customerRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerLogic"/> class.
        /// </summary>
        /// <param name="customerRepo">Repository of customer.</param>
        public CustomerLogic(ICustomerRepository customerRepo)
        {
            this.customerRepo = customerRepo;
        }

        /// <inheritdoc/>
        public void ChangePassword(int id, string newPassword)
        {
            this.customerRepo.ChangePassword(id, newPassword);
        }

        /// <inheritdoc/>
        public void CreateCustomer(Customer entity)
        {
            this.customerRepo.Insert(entity);
        }

        /// <inheritdoc/>
        public bool DeleteCustomer(int id)
        {
            return this.customerRepo.Remove(id);
        }

        /// <inheritdoc/>
        public IList<Customer> GetAllCustomers()
        {
            return this.customerRepo.GetAll().ToList();
        }

        /// <inheritdoc/>
        public Customer GetCustomerById(int id)
        {
            return this.customerRepo.GetOne(id);
        }
    }
}
