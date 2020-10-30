namespace SkiRental.Repository
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using SkiRental.Data;

    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderRepository"/> class.
        /// </summary>
        /// <param name="ctx"></param>
        public OrderRepository(DbContext ctx)
            : base(ctx) { }

        /// <inheritdoc/>
        public void Add()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public void Delete()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public override Order GetOne(int id)
        {
            throw new NotImplementedException();
        }
    }
}
