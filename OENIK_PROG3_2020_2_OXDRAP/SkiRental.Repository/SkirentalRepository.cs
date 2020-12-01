// <copyright file="SkirentalRepository.cs" company="OXDRAP">
// Copyright (c) OXDRAP. All rights reserved.
// </copyright>

namespace SkiRental.Repository
{
    using System;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// This is the main repository.
    /// </summary>
    /// <typeparam name="T">Generic type.</typeparam>
    public abstract class SkirentalRepository<T> : IRepository<T>
        where T : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SkirentalRepository{T}"/> class.
        /// </summary>
        /// <param name="ctx">Context.</param>
        protected SkirentalRepository(DbContext ctx)
        {
            this.Ctx = ctx;
        }

        /// <summary>
        /// Gets or sets the context.
        /// </summary>
        protected DbContext Ctx { get; set; }

        /// <inheritdoc/>
        public IQueryable<T> GetAll()
        {
            return this.Ctx.Set<T>();
        }

        /// <inheritdoc/>
        public abstract T GetOne(int id);

        /// <inheritdoc/>
        public void Insert(T entity)
        {
            this.Ctx.Set<T>().Add(entity);
            this.Ctx.SaveChanges();
        }

        /// <inheritdoc/>
        public bool Remove(int id)
        {
            if (this.GetOne(id) != null)
            {
                this.Ctx.Set<T>().Remove(this.GetOne(id));
                this.Ctx.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
