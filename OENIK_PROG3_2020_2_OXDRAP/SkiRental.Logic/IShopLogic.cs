// <copyright file="IShopLogic.cs" company="OXDRAP">
// Copyright (c) OXDRAP. All rights reserved.
// </copyright>

namespace SkiRental.Logic
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
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
        IList<PaidResult> PaidHead();

        /// <summary>
        /// It lists all the skis, that have promotion.
        /// </summary>
        /// <returns>List of equipments.</returns>
        IList<PromotionResult> PromotionOver170();

        /// <summary>
        /// Lists all the beginner customers who use credit card.
        /// </summary>
        /// <returns>List of customers.</returns>
        IList<BeginnersResult> BeginnersWithCreditCard();

        /// <summary>
        /// It removes an entity by ID.
        /// </summary>
        /// <param name="id">ID.</param>
        /// <returns>It returns the entity does exists.</returns>
        bool DeleteOrder(int id);

        /// <summary>
        /// It removes an entity by ID.
        /// </summary>
        /// <param name="id">ID.</param>
        /// <returns>It returns the entity does exists.</returns>
        bool DeleteEquipment(int id);

        /// <summary>
        /// It lists all the Head skis for which they have already been paid.
        /// </summary>
        /// <returns>An async list.</returns>
        Task<IList<PaidResult>> PaidHeadAsync();

        /// <summary>
        /// It lists all the skis, that have promotion.
        /// </summary>
        /// <returns>An async list.</returns>
        Task<IList<PromotionResult>> PromotionOver170Async();

        /// <summary>
        /// Lists all the beginner customers who use credit card.
        /// </summary>
        /// <returns>An async list.</returns>
        Task<IList<BeginnersResult>> BeginnersWithCreditCardAsync();
    }
}
