// <copyright file="ICustomerRepository.cs" company="OXDRAP">
// Copyright (c) OXDRAP. All rights reserved.
// </copyright>

namespace SkiRental.Repository
{
    using SkiRental.Data;

    /// <summary>
    /// It is the repository interface of the Customers table.
    /// </summary>
    public interface ICustomerRepository : IRepository<Customer>
    {
        /// <summary>
        /// It changes the password of an entity by ID.
        /// </summary>
        /// <param name="id">ID of the entity.</param>
        /// <param name="newPassword">New password.</param>
        void ChangePassword(int id, string newPassword);
    }
}
