using Microsoft.EntityFrameworkCore;
using System;
using SkiRental.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental.Repository
{
    public abstract class Repository<T> : IRepository<T>
        where T : class
    {
        protected DbContext ctx;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{T}"/> class.
        /// </summary>
        /// <param name="ctx"></param>
        public Repository(DbContext ctx)
        {
            this.ctx = ctx;
        }

        /// <inheritdoc/>
        public IQueryable<T> GetAll()
        {
            return ctx.Set<T>();
        }

        /// <inheritdoc/>
        public abstract T GetOne(int id);
    }
}
