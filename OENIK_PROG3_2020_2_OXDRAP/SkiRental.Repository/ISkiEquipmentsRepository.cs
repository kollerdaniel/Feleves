// <copyright file="ISkiEquipmentsRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SkiRental.Repository
{
    using SkiRental.Data;

    public interface ISkiEquipmentsRepository : IRepository<SkiEquipments>
    {
        void ChangePrice(int id, int newPrice);
    }
}
