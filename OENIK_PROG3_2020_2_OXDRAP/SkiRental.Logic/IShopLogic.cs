﻿// <copyright file="IShopLogic.cs" company="OXDRAP">
// Copyright (c) OXDRAP. All rights reserved.
// </copyright>

namespace SkiRental.Logic
{
    using System.Collections.Generic;
    using SkiRental.Data;

    /// <summary>
    /// This is the interface of the logic class of the Orders and the SkiEquipments.
    /// </summary>
    public interface IShopLogic
    {
        /// <summary>
        /// This is the get one method.
        /// </summary>
        /// <param name="id">ID.</param>
        /// <returns>It returns one entity by ID.</returns>
        Order GetOrderById(int id);

        /// <summary>
        /// It changes the payment method by ID.
        /// </summary>
        /// <param name="id">ID of the entity.</param>
        /// <param name="paymentMethod">The new payment method.</param>
        void ChangePayment(int id, string paymentMethod);

        /// <summary>
        /// This is the get all method for the Orders table.
        /// </summary>
        /// <returns>It returns a list of the entities.</returns>
        IList<Order> GetAllOrders();

        /// <summary>
        /// This is the get one method.
        /// </summary>
        /// <param name="id">ID of the entity.</param>
        /// <returns>It returns an entity by ID.</returns>
        SkiEquipments GetSkiEquipmentsById(int id);

        /// <summary>
        /// It changes the price of the entity.
        /// </summary>
        /// <param name="id">ID of the entity.</param>
        /// <param name="newPrice">New price.</param>
        void ChangePrice(int id, int newPrice);

        /// <summary>
        /// This is the get all method for the Orders table.
        /// </summary>
        /// <returns>It returns a list of the entities.</returns>
        IList<SkiEquipments> GetAllSkiEquipments();

        /// <summary>
        /// It creates a new order.
        /// </summary>
        /// <param name="entity">New entity.</param>
        void CreateOrder(Order entity);

        /// <summary>
        /// It creates a new equipment.
        /// </summary>
        /// <param name="entity">New entity.</param>
        void CreateEquipment(SkiEquipments entity);

        /// <summary>
        /// It lists all the Head skis for which they have already been paid.
        /// </summary>
        /// <returns>List of equipments.</returns>
        IList<string> PaidHead();

        /// <summary>
        /// It lists all the skis, that have promotion.
        /// </summary>
        /// <returns>List of equipments.</returns>
        IList<string> PromotionOver170();

        /// <summary>
        /// Lists all the beginner customers who use credit card.
        /// </summary>
        /// <returns>List of customers.</returns>
        IList<string> BeginnersWithCreditCard();
    }
}
