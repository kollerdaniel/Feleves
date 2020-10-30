// <copyright file="ICustomerLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SkiRental.Logic
{
    using System.Collections;
    using System.Collections.Generic;
    using SkiRental.Data;

    public interface ICustomerLogic
    {
        Customer GetCustomerById(int id);

        void ChangePassword(int id, string newPassword);

        IList<Customer> GetAllCustomers();
    }
}
