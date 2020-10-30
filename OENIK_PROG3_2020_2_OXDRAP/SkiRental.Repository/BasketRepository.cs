// <copyright file="BasketRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SkiRental.Repository
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using SkiRental.Data;

    public class BasketRepository : SkirentalRepository<Basket>, IBasketRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BasketRepository"/> class.
        /// </summary>
        /// <param name="ctx"></param>
        public BasketRepository(DbContext ctx)
            : base(ctx) { }

        /// <inheritdoc/>
        public override Basket GetOne(int id)
        {
            throw new NotImplementedException();
        }
    }
}
