// <copyright file="CustomerRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SkiRental.Repository
{
    using System;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using SkiRental.Data;

    public class CustomerRepository : SkirentalRepository<Customer>, ICustomerRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerRepository"/> class.
        /// </summary>
        /// <param name="ctx"></param>
        public CustomerRepository(DbContext ctx)
            : base(ctx) { }

        /// <inheritdoc/>
        public void ChangePassword(int id, string newPassword)
        {
            var customer = this.GetOne(id);

            if (customer == null)
            {
                throw new InvalidOperationException("not found");
            }

            customer.Password = newPassword;

            this.ctx.SaveChanges();
        }

        /// <inheritdoc/>
        public override Customer GetOne(int id)
        {
            return GetAll().SingleOrDefault(x => x.CustomerId == id);
        }
    }
}
