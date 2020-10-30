using Microsoft.EntityFrameworkCore;
using System;
using SkiRental.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental.Repository
{
    public class BasketRepository : Repository<Basket>, IBasketRepository
    {
        public BasketRepository(DbContext ctx) : base(ctx) { }

        public void Add()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public override Basket GetOne(int id)
        {
            throw new NotImplementedException();
        }
    }
}
