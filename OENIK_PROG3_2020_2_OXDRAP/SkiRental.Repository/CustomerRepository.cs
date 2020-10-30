// <copyright file="CustomerRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SkiRental.Repository
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using SkiRental.Data;

    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DbContext ctx) : base(ctx) { }

        /// <inheritdoc/>
        public void Add()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public void Delete()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public override Customer GetOne(int id)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
