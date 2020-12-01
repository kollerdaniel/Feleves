// <copyright file="ICustomerLogic.cs" company="OXDRAP">
// Copyright (c) OXDRAP. All rights reserved.
// </copyright>

namespace SkiRental.Logic
{
    using System.Collections.Generic;
    using SkiRental.Data;

    /// <summary>
    /// This is the interface of the logic class of the Customers.
    /// </summary>
    public interface ICustomerLogic
    {
        /// <summary>
        /// This is the get one method.
        /// </summary>
        /// <param name="id">ID.</param>
        /// <returns>It returns one entity by ID.</returns>
        Customer GetCustomerById(int id);

        /// <summary>
        /// It changes the password by ID.
        /// </summary>
        /// <param name="id">ID of an entity.</param>
        /// <param name="newPassword">New password.</param>
        void ChangePassword(int id, string newPassword);

        /// <summary>
        /// This is the get all method for the Customers table.
        /// </summary>
        /// <returns>It returns a list of the entities.</returns>
        IList<Customer> GetAllCustomers();
    }
}
