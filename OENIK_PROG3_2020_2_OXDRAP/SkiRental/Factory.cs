using ConsoleTools;
using SkiRental.Data;
using SkiRental.Logic;
using SkiRental.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental.Program
{
    class Factory
    {
        private static SkiRentalContext ctx = new SkiRentalContext();

        private static SkiEquipmentsRepository equipmentRepo = new SkiEquipmentsRepository(ctx);

        private static OrderRepository orderRepo = new OrderRepository(ctx);

        private static CustomerRepository customerRepo = new CustomerRepository(ctx);

        private static CustomerLogic customerLogic = new CustomerLogic(customerRepo);

        private static ShopLogic shopLogic = new ShopLogic(orderRepo, equipmentRepo);

        public void Start()
        {
            var menu = new ConsoleMenu()
                .Add(">> LIST ALL Customers", () => ListAllC(customerLogic))
                .Add(">> LIST ALL Orders", () => ListAllO(shopLogic))
                .Add(">> LIST ALL Equipments", () => ListAllS(shopLogic))
                .Add(">> EXIT", ConsoleMenu.Close);

            menu.Show();
        }

        private static void ListAllC(CustomerLogic customerLogic)
        {
            Console.WriteLine("\n:: ALL Customers ::\n");
            customerLogic.GetAllCustomers()
                .ToList()
                .ForEach(x => Console.WriteLine(x.ToString()));
            ;
            Console.ReadLine();
        }

        private static void ListAllO(ShopLogic shopL)
        {
            Console.WriteLine("\n:: ALL Orders ::\n");
            shopL.GetAllOrders()
                .ToList()
                .ForEach(x => Console.WriteLine(x.ToString()));

            Console.ReadLine();
        }

        private static void ListAllS(ShopLogic shopL)
        {
            Console.WriteLine("\n:: ALL Equipments ::\n");
            shopL.GetAllSkiEquipments()
                .ToList()
                .ForEach(x => Console.WriteLine(x.ToString()));

            Console.ReadLine();
        }
    }
}
