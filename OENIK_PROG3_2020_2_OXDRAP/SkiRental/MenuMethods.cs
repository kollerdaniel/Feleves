namespace SkiRental.Program
{
    using System;
    using System.Linq;
    using SkiRental.Logic;

    public class MenuMethods
    {
        public static void ListAllC(CustomerLogic customerLogic)
        {

            const string value = "\n:: ALL Customers ::\n";

            Console.WriteLine(value);
            customerLogic.GetAllCustomers()
                .ToList()
                .ForEach(x => Console.WriteLine(x.ToString()));
            ;
            Console.ReadLine();
        }

        public static void ListAllO(ShopLogic shopL)
        {
            const string value = "\n:: ALL Orders ::\n";
            Console.WriteLine(value);
            shopL.GetAllOrders()
                .ToList()
                .ForEach(x => Console.WriteLine(x.ToString()));

            Console.ReadLine();
        }

        public static void ListAllS(ShopLogic shopL)
        {
            const string value = "\n:: ALL Equipments ::\n";
            Console.WriteLine(value);
            shopL.GetAllSkiEquipments()
                .ToList()
                .ForEach(x => Console.WriteLine(x.ToString()));

            Console.ReadLine();
        }

        public static void GetOneCustomer(CustomerLogic customerLogic)
        {
            Console.WriteLine("Enter id here: ");

            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("\n:: Selected Customer ::\n");

            Console.WriteLine(customerLogic.GetCustomerById(id).ToString());

            Console.ReadLine();
        }

        public static void GetOneOrder(ShopLogic shopLogic)
        {
            Console.WriteLine("Enter id here: ");

            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("\n:: Selected Order ::\n");

            Console.WriteLine(shopLogic.GetOrderById(id).ToString());

            Console.ReadLine();
        }

        public static void GetOneEquipment(ShopLogic shopLogic)
        {
            Console.WriteLine("Enter id here: ");

            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("\n:: Selected Equipment ::\n");

            Console.WriteLine(shopLogic.GetSkiEquipmentsById(id).ToString());

            Console.ReadLine();
        }

        public static void ChangePassword(CustomerLogic customerLogic)
        {
            Console.WriteLine("Enter id here: ");

            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter new password here: ");

            string password = Console.ReadLine();

            customerLogic.ChangePassword(id, password);

            Console.WriteLine("Elmentve!!!");

            Console.ReadLine();
        }
    }
}
