// <copyright file="SkiEquipmentsRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SkiRental.Repository
{
    using System;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using SkiRental.Data;

    public class SkiEquipmentsRepository : SkirentalRepository<SkiEquipments>, ISkiEquipmentsRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SkiEquipmentsRepository"/> class.
        /// </summary>
        /// <param name="ctx"></param>
        public SkiEquipmentsRepository(DbContext ctx)
            : base(ctx) { }

        /// <inheritdoc/>
        public void ChangePrice(int id, int newPrice)
        {
            var equipment = this.GetOne(id);

            if (equipment == null)
            {
                throw new InvalidOperationException("not found");
            }

            equipment.Price = newPrice;

            this.ctx.SaveChanges();
        }

        /// <inheritdoc/>
        public override SkiEquipments GetOne(int id)
        {
            return GetAll().SingleOrDefault(x => x.SkiEquipmentsId == id);
        }
    }
}
