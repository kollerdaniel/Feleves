namespace SkiRental.Program
{
    using ConsoleTools;
    using SkiRental.Data;
    using SkiRental.Logic;
    using SkiRental.Repository;

    public class Factory
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
                .Add("Új jelszó megadása", () => MenuMethods.ChangePassword(customerLogic))
                .Add("Vissza", ConsoleMenu.Close).Show())
                .Add("CREATE ...", () => new ConsoleMenu()
                .Add("Ez még nincs kész, vissza", ConsoleMenu.Close).Show())
                .Add("DELETE ...", () => new ConsoleMenu()
                .Add("Ez még nincs kész, vissza", ConsoleMenu.Close).Show())
                .Add(">> EXIT", ConsoleMenu.Close);

            menu.Show();
        }
    }
}
