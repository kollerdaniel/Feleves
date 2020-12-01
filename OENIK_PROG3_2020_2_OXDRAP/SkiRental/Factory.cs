// <copyright file="Factory.cs" company="OXDRAP">
// Copyright (c) OXDRAP. All rights reserved.
// </copyright>

namespace SkiRental.Program
{
    using ConsoleTools;
    using SkiRental.Data;
    using SkiRental.Logic;
    using SkiRental.Repository;

    /// <summary>
    /// It instantiates the repositories, the logic classes and the menu.
    /// </summary>
    public static class Factory
    {
        private static SkiRentalContext ctx = new SkiRentalContext();

        private static SkiEquipmentsRepository equipmentRepo = new SkiEquipmentsRepository(ctx);

        private static OrderRepository orderRepo = new OrderRepository(ctx);

        private static CustomerRepository customerRepo = new CustomerRepository(ctx);

        private static CustomerLogic customerLogic = new CustomerLogic(customerRepo);

        private static ShopLogic shopLogic = new ShopLogic(orderRepo, equipmentRepo);

        /// <summary>
        /// This is a method to handle the menu.
        /// </summary>
        public static void Start()
        {
            var menu = new ConsoleMenu()

                .Add(">> LIST ALL ...", () => new ConsoleMenu()
                .Add("LIST ALL Customers", () => MenuMethods.ListAllC(customerLogic))
                .Add(">> LIST ALL Orders", () => MenuMethods.ListAllO(shopLogic))
                .Add(">> LIST ALL Equipments", () => MenuMethods.ListAllS(shopLogic))
                .Add("Back", ConsoleMenu.Close).Show())
                .Add("One of them ...", () => new ConsoleMenu()
                .Add("Customer", () => MenuMethods.GetOneCustomer(customerLogic))
                .Add("Order", () => MenuMethods.GetOneOrder(shopLogic))
                .Add("Ski equipment", () => MenuMethods.GetOneEquipment(shopLogic))
                .Add("Back", ConsoleMenu.Close).Show())
                .Add("UPDATE ...", () => new ConsoleMenu()
                .Add("Customer => New password", () => MenuMethods.ChangePassword(customerLogic))
                .Add("Order => New price", () => MenuMethods.ChangePrice(shopLogic))
                .Add("Order => New payment method", () => MenuMethods.ChangePayment(shopLogic))
                .Add("Back", ConsoleMenu.Close).Show())
                .Add("CREATE ...", () => new ConsoleMenu()
                .Add("Create Customer", () => MenuMethods.InsertCustomer(customerLogic))
                .Add("Create Order", () => MenuMethods.InsterOrder(shopLogic))
                .Add("Create Equipment", () => MenuMethods.InsterEquipment(shopLogic))
                .Add("Back", ConsoleMenu.Close).Show())
                .Add("DELETE ...", () => new ConsoleMenu()
                .Add("Delete Customer", () => MenuMethods.DeleteCustomer(customerRepo))
                .Add("Delete Order", () => MenuMethods.DeleteOrder(orderRepo))
                .Add("Delete Equipment", () => MenuMethods.DeleteEquipment(equipmentRepo))
                .Add("Back", ConsoleMenu.Close).Show())
                .Add(">> EXIT", ConsoleMenu.Close);

            menu.Show();
        }
    }
}
