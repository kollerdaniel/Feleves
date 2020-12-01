// <copyright file="ISkiEquipmentsRepository.cs" company="OXDRAP">
// Copyright (c) OXDRAP. All rights reserved.
// </copyright>

namespace SkiRental.Repository
{
    using SkiRental.Data;

    /// <summary>
    /// This is the repository interface of the SkiEquipments table.
    /// </summary>
    public interface ISkiEquipmentsRepository : IRepository<SkiEquipments>
    {
        /// <summary>
        /// It changes the price of the entity.
        /// </summary>
        /// <param name="id">ID of the entity.</param>
        /// <param name="newPrice">New price.</param>
        void ChangePrice(int id, int newPrice);
    }
}
