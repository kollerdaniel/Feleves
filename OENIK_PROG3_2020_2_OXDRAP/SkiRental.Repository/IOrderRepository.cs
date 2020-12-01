// <copyright file="IOrderRepository.cs" company="OXDRAP">
// Copyright (c) OXDRAP. All rights reserved.
// </copyright>

namespace SkiRental.Repository
{
    using SkiRental.Data;

    /// <summary>
    /// This is the repository interface of the Orders table.
    /// </summary>
    public interface IOrderRepository : IRepository<Order>
    {
        /// <summary>
        /// It changes the payment method by ID.
        /// </summary>
        /// <param name="id">ID of the entity.</param>
        /// <param name="paymentMethod">The new payment method.</param>
        void ChangePayment(int id, string paymentMethod);
    }
}
