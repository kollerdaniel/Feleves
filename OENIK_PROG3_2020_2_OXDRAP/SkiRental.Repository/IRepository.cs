﻿// <copyright file="IRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SkiRental.Repository
{
    using System.Linq;
    using SkiRental.Data;

    public interface IRepository<T>
        where T : class
    {
        T GetOne(int id);

        IQueryable<T> GetAll();

        void Insert(T entity);

        void Remove(T entity);
    }
}