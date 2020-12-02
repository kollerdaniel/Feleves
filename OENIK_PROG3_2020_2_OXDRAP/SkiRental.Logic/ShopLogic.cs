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
        public IList<string> PaidHead()
        {
            var q1 = from x in this.equipmentRepo.GetAll()
                     join order in this.orderRepo.GetAll()
                     on x.OrderId equals order.OrderId
                     where x.Manufacturer == "Head" && order.CustomerPaid == true
                     select new
                     {
                         _Name = x.Name,
                         _Manufacturer = x.Manufacturer,
                         _Difficulty = x.Difficulty,
                         _Price = x.Price,
                         _Size = x.Size,
                         _Status = x.Status,
                     };
            List<string> result = new List<string>();
            for (int i = 0; i < q1.ToArray().Length; i++)
            {
                result.Add($"Name: {q1.ToArray()[i]._Name}, manufacturer: {q1.ToArray()[i]._Manufacturer}, price: {q1.ToArray()[i]._Price}, size: {q1.ToArray()[i]._Size}, difficulty: {q1.ToArray()[i]._Difficulty}, status: {q1.ToArray()[i]._Status}");
            }

            return result;
        }

        /// <inheritdoc/>
        public IList<string> PromotionOver170()
        {
            var q = from x in this.equipmentRepo.GetAll()
                    join order in this.orderRepo.GetAll()
                    on x.OrderId equals order.OrderId
                    where x.Size > 170 && order.Promotion != null
                    select new
                    {
                        _size = x.Size,
                        _promotion = order.Promotion,
                    };
            List<string> result = new List<string>();
            for (int i = 0; i < q.ToArray().Length; i++)
            {
                result.Add($"Size: {q.ToArray()[i]._size}, promotion: {q.ToArray()[i]._promotion}");
            }

            return result;
        }

        /// <inheritdoc/>
        public IList<string> BeginnersWithCreditCard()
        {
            var q = from x in this.orderRepo.GetAll()
                    where x.Customer.Difficulty == "beginner" && x.Payment == "Credit Card"
                    select new
                    {
                        _Name = x.Customer.Name,
                        _diff = x.Customer.Difficulty,
                        _payment = x.Payment,
                    };
            List<string> result = new List<string>();
            for (int i = 0; i < q.ToArray().Length; i++)
            {
                result.Add($"Name: {q.ToArray()[i]._Name}, difficulty: {q.ToArray()[i]._diff}, payment method: {q.ToArray()[i]._payment}");
            }

            return result;
        }
    }
}
