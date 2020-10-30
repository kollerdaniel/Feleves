using Microsoft.EntityFrameworkCore;
using System;
using SkiRental.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental.Repository
{
    public class SkiEquipmentsRepository : Repository<SkiEquipments>, ISkiEquipmentsRepository
    {
        public SkiEquipmentsRepository(DbContext ctx) : base(ctx) { }

        public void Add()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public override SkiEquipments GetOne(int id)
        {
            throw new NotImplementedException();
        }
    }
}
