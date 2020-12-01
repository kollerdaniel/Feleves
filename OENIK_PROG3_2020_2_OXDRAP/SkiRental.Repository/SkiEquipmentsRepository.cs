// <copyright file="SkiEquipmentsRepository.cs" company="OXDRAP">
// Copyright (c) OXDRAP. All rights reserved.
// </copyright>

namespace SkiRental.Repository
{
    using System;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using SkiRental.Data;

    /// <summary>
    /// This is the repository of the ski equipments.
    /// </summary>
    public class SkiEquipmentsRepository : SkirentalRepository<SkiEquipments>, ISkiEquipmentsRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SkiEquipmentsRepository"/> class.
        /// </summary>
        /// <param name="ctx">Context.</param>
        public SkiEquipmentsRepository(DbContext ctx)
            : base(ctx)
        {
        }

        /// <inheritdoc/>
        public void ChangePrice(int id, int newPrice)
        {
            var equipment = this.GetOne(id);

            if (equipment == null)
            {
                throw new InvalidOperationException("not found");
            }

            equipment.Price = newPrice;

            this.Ctx.SaveChanges();
        }

        /// <inheritdoc/>
        public override SkiEquipments GetOne(int id)
        {
            SkiEquipments s = this.GetAll().SingleOrDefault(x => x.SkiEquipmentsId == id);

            if (s != null)
            {
                return s;
            }
            else
            {
                throw new ArgumentException("Could not find the record in the set!");
            }
        }
    }
}
