// <copyright file="CustomerRepository.cs" company="OXDRAP">
// Copyright (c) OXDRAP. All rights reserved.
// </copyright>

namespace SkiRental.Repository
{
    using System;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using SkiRental.Data;

    /// <summary>
    /// It is the repository of the Customers table.
    /// </summary>
    public class CustomerRepository : SkirentalRepository<Customer>, ICustomerRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerRepository"/> class.
        /// </summary>
        /// <param name="ctx">Context.</param>
        public CustomerRepository(DbContext ctx)
            : base(ctx)
        {
        }

        /// <inheritdoc/>
        public void ChangePassword(int id, string newPassword)
        {
            var customer = this.GetOne(id);

            if (customer == null)
            {
                throw new InvalidOperationException("not found");
            }

            customer.Password = newPassword;

            this.Ctx.SaveChanges();
        }

        /// <inheritdoc/>
        public override Customer GetOne(int id)
        {
            Customer c = this.GetAll().SingleOrDefault(x => x.CustomerId == id);
            if (c != null)
            {
                return c;
            }
            else
            {
                throw new ArgumentException("Could not find the record in the set!");
            }
        }
    }
}
