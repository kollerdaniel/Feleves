// <copyright file="OrderRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SkiRental.Repository
{
    using System;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using SkiRental.Data;

    public class OrderRepository : SkirentalRepository<Order>, IOrderRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderRepository"/> class.
        /// </summary>
        /// <param name="ctx"></param>
        public OrderRepository(DbContext ctx)
            : base(ctx) { }

        /// <inheritdoc/>
        public void ChangePayment(int id, string paymentMethod)
        {
            var order = this.GetOne(id);

            if (order == null)
            {
                throw new InvalidOperationException("not found");
            }

            order.Payment = paymentMethod;

            this.ctx.SaveChanges();
        }

        /// <inheritdoc/>
        public override Order GetOne(int id)
        {
            return GetAll().SingleOrDefault(x => x.OrderId == id);
        }
    }
}
