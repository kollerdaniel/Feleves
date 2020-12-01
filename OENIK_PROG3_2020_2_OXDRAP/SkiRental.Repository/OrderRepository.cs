// <copyright file="OrderRepository.cs" company="OXDRAP">
// Copyright (c) OXDRAP. All rights reserved.
// </copyright>

namespace SkiRental.Repository
{
    using System;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using SkiRental.Data;

    /// <summary>
    /// This is the repository of the Orders table.
    /// </summary>
    public class OrderRepository : SkirentalRepository<Order>, IOrderRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderRepository"/> class.
        /// </summary>
        /// <param name="ctx">Context.</param>
        public OrderRepository(DbContext ctx)
            : base(ctx)
        {
        }

        /// <inheritdoc/>
        public void ChangePayment(int id, string paymentMethod)
        {
            var order = this.GetOne(id);

            if (order == null)
            {
                throw new InvalidOperationException("not found");
            }

            order.Payment = paymentMethod;

            this.Ctx.SaveChanges();
        }

        /// <inheritdoc/>
        public override Order GetOne(int id)
        {
            Order o = this.GetAll().SingleOrDefault(x => x.OrderId == id);
            if (o != null)
            {
                return o;
            }
            else
            {
                throw new ArgumentException("Could not find the record in the set!");
            }
        }
    }
}
