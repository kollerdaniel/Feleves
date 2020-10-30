using SkiRental.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental.Repository
{
    public interface IRepository<T> where T : class
    {
        T GetOne(int id);
        IQueryable<T> GetAll();
    }

    public interface ICustomerRepository : IRepository<Customer>
    {
        void Add();
        void Update();
        void Delete();
    }
    public interface IOrderRepository : IRepository<Order>
    {
        void Add();
        void Delete();
    }
    public interface ISkiEquipmentsRepository : IRepository<SkiEquipments>
    {
        void Add();
        void Delete();
    }
    public interface IBasketRepository : IRepository<Basket>
    {
        void Add();
        void Delete();
    }
}
