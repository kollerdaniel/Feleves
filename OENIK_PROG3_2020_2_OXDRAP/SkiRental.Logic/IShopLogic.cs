// <copyright file="IShopLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SkiRental.Logic
{
    using System.Collections.Generic;
    using SkiRental.Data;

    public interface IShopLogic
    {
        Order GetOrderById(int id);

        void ChangePayment(int id, string paymentMethod);

        IList<Order> GetAllOrders();

        SkiEquipments GetSkiEquipmentsById(int id);

        void ChangePrice(int id, int newPrice);

        IList<SkiEquipments> GetAllSkiEquipments();
    }
}
