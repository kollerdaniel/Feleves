using SkiRental.Data;
using SkiRental.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental.Logic
{
    public class ShopLogic : IShopLogic
    {
        IOrderRepository orderRepo;

        ISkiEquipmentsRepository equipmentRepo;

        public ShopLogic(IOrderRepository orderRepository, ISkiEquipmentsRepository skiEquipmentsRepository)
        {
            this.orderRepo = orderRepository;
            this.equipmentRepo = skiEquipmentsRepository;
        }

        public void ChangePayment(int id, string paymentMethod)
        {
            orderRepo.ChangePayment(id, paymentMethod);
        }

        public void ChangePrice(int id, int newPrice)
        {
            equipmentRepo.ChangePrice(id, newPrice);
        }

        public IList<Order> GetAllOrders()
        {
            return orderRepo.GetAll().ToList();
        }

        public IList<SkiEquipments> GetAllSkiEquipments()
        {
            return equipmentRepo.GetAll().ToList();
        }

        public Order GetOrderById(int id)
        {
            return orderRepo.GetOne(id);
        }

        public SkiEquipments GetSkiEquipmentsById(int id)
        {
            return equipmentRepo.GetOne(id);
        }
    }
}
