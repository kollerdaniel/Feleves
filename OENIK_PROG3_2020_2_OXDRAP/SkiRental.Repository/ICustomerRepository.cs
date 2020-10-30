// <copyright file="ICustomerRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SkiRental.Repository
{
    using SkiRental.Data;

    public interface ICustomerRepository : IRepository<Customer>
    {
        void ChangePassword(int id, string newPassword);
    }
}
