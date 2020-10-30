// <copyright file="IOrderRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SkiRental.Repository
{
    using SkiRental.Data;

    public interface IOrderRepository : IRepository<Order>
    {
        void ChangePayment(int id, string paymentMethod);
    }
}
