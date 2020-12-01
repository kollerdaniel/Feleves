// <copyright file="ShopLogic.cs" company="OXDRAP">
// Copyright (c) OXDRAP. All rights reserved.
// </copyright>

namespace SkiRental.Logic
{
    using System.Collections.Generic;
    using System.Linq;
    using SkiRental.Data;
    using SkiRental.Repository;

    /// <summary>
    /// This is the logic class of the Orders and the SkiEquipments.
    /// </summary>
    public class ShopLogic : IShopLogic
    {
        private IOrderRepository orderRepo;

        private ISkiEquipmentsRepository equipmentRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShopLogic"/> class.
        /// </summary>
        /// <param name="orderRepository">Repository of the orders.</param>
        /// <param name="skiEquipmentsRepository">Repository of the ski equipments.</param>
        public ShopLogic(IOrderRepository orderRepository, ISkiEquipmentsRepository skiEquipmentsRepository)
        {
            this.orderRepo = orderRepository;
            this.equipmentRepo = skiEquipmentsRepository;
        }

        /// <inheritdoc/>
        public void ChangePayment(int id, string paymentMethod)
        {
            this.orderRepo.ChangePayment(id, paymentMethod);
        }

        /// <inheritdoc/>
        public void ChangePrice(int id, int newPrice)
        {
            this.equipmentRepo.ChangePrice(id, newPrice);
        }

        /// <inheritdoc/>
        public void CreateEquipment(SkiEquipments entity)
        {
            this.equipmentRepo.Insert(entity);
        }

        /// <inheritdoc/>
        public void CreateOrder(Order entity)
        {
            this.orderRepo.Insert(entity);
        }

        /// <inheritdoc/>
        public IList<Order> GetAllOrders()
        {
            return this.orderRepo.GetAll().ToList();
        }

        /// <inheritdoc/>
        public IList<SkiEquipments> GetAllSkiEquipments()
        {
            return this.equipmentRepo.GetAll().ToList();
        }

        /// <inheritdoc/>
        public Order GetOrderById(int id)
        {
            return this.orderRepo.GetOne(id);
        }

        /// <inheritdoc/>
        public SkiEquipments GetSkiEquipmentsById(int id)
        {
            return this.equipmentRepo.GetOne(id);
        }
    }
}
