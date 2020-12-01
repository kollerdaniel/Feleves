// <copyright file="IRepository.cs" company="OXDRAP">
// Copyright (c) OXDRAP. All rights reserved.
// </copyright>

namespace SkiRental.Repository
{
    using System.Linq;
    using SkiRental.Data;

    /// <summary>
    /// This is the main repository inteface.
    /// </summary>
    /// <typeparam name="T">Generic type.</typeparam>
    public interface IRepository<T>
        where T : class
    {
        /// <summary>
        /// This is the get one method.
        /// </summary>
        /// <param name="id">ID of the entity.</param>
        /// <returns>It returns an entity by ID.</returns>
        T GetOne(int id);

        /// <summary>
        /// This is the get all method.
        /// </summary>
        /// <returns>It returns a list of the entities.</returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// It adds an entity to the database.
        /// </summary>
        /// <param name="entity">Entity.</param>
        void Insert(T entity);

        /// <summary>
        /// It removes an entity by ID.
        /// </summary>
        /// <param name="id">ID.</param>
        void Remove(int id);
    }
}
