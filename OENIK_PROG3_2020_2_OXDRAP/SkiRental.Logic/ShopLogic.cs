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

        /// <inheritdoc/>
        public IList<PaidResult> PaidHead()
        {
            var q1 = from x in this.equipmentRepo.GetAll()
                     join order in this.orderRepo.GetAll()
                     on x.OrderId equals order.OrderId
                     where x.Manufacturer == "Head" && order.CustomerPaid == true
                     select new PaidResult()
                     {
                         Name = x.Name,
                         Manufacturer = x.Manufacturer,
                         Size = x.Size,
                     };

            return q1.ToList();
        }

        /// <inheritdoc/>
        public IList<PromotionResult> PromotionOver170()
        {
            var q = from x in this.equipmentRepo.GetAll()
                    join order in this.orderRepo.GetAll()
                    on x.OrderId equals order.OrderId
                    where x.Size > 170 && order.Promotion != null
                    select new PromotionResult()
                    {
                        Size = x.Size,
                        Promotion = order.Promotion,
                    };

            return q.ToList();
        }

        /// <inheritdoc/>
        public IList<BeginnersResult> BeginnersWithCreditCard()
        {
            var q = from x in this.orderRepo.GetAll()
                    where x.Customer.Difficulty == "beginner" && x.Payment == "Credit Card"
                    select new BeginnersResult()
                    {
                        Name = x.Customer.Name,
                        Diff = x.Customer.Difficulty,
                        Payment = x.Payment,
                    };

            return q.ToList();
        }

        /// <inheritdoc/>
        public bool DeleteOrder(int id)
        {
            return this.orderRepo.Remove(id);
        }

        /// <inheritdoc/>
        public bool DeleteEquipment(int id)
        {
            return this.equipmentRepo.Remove(id);
        }
    }
}
