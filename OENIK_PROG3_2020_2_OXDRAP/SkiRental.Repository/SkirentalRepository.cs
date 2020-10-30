// <copyright file="Repository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SkiRental.Repository
{
    using System;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;

    public abstract class SkirentalRepository<T> : IRepository<T>
        where T : class
    {
        protected DbContext ctx;

        /// <summary>
        /// Initializes a new instance of the <see cref="SkirentalRepository{T}"/> class.
        /// </summary>
        /// <param name="ctx"></param>
        public SkirentalRepository(DbContext ctx)
        {
            this.ctx = ctx;
        }

        /// <inheritdoc/>
        public IQueryable<T> GetAll()
        {
            return this.ctx.Set<T>();
        }

        /// <inheritdoc/>
        public abstract T GetOne(int id);

        /// <inheritdoc/>
        public void Insert(T entity)
        {
            this.ctx.Set<T>().Add(entity);
            this.ctx.SaveChanges();
        }

        public void Remove(int id)
        {
            this.ctx.Set<T>().Remove(this.GetOne(id));
            this.ctx.SaveChanges();
        }
    }
}
