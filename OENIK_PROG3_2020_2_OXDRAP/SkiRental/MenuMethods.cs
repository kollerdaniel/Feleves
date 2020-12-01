// <copyright file="MenuMethods.cs" company="OXDRAP">
// Copyright (c) OXDRAP. All rights reserved.
// </copyright>

namespace SkiRental.Program
{
    using System;
    using System.Globalization;
    using System.Linq;
    using SkiRental.Logic;

    /// <summary>
    /// This is a class for the methods that menu uses.
    /// </summary>
    public static class MenuMethods
    {
        private const string Enter = "Enter id here: ";
        private const string Selected = "\n:: Selected Item ::\n";
        private const string Other = "Try an other ID:";
        private const string Saved = "Saved!";

        /// <summary>
        /// This method lists all the customers.
        /// </summary>
        /// <param name="customerLogic">Logic for Customers repository.</param>
        public static void ListAllC(CustomerLogic customerLogic)
        {
            const string value = "\n:: ALL Customers ::\n";

            Console.WriteLine(value.ToString());
            customerLogic?.GetAllCustomers()
                .ToList()
                .ForEach(x => Console.WriteLine(x.ToString()));
            Console.ReadLine();
        }

        /// <summary>
        /// This method lists all the Orders.
        /// </summary>
        /// <param name="shopL">Logic for Orders repository and SkiEqupments repository.</param>
        public static void ListAllO(ShopLogic shopL)
        {
            const string value = "\n:: ALL Orders ::\n";
            Console.WriteLine(value.ToString());
            shopL?.GetAllOrders()
                .ToList()
                .ForEach(x => Console.WriteLine(x.ToString()));

            Console.ReadLine();
        }

        /// <summary>
        /// This method lists all the Ski equipments.
        /// </summary>
        /// <param name="shopL">Logic for Orders repository and SkiEqupments repository.</param>
        public static void ListAllS(ShopLogic shopL)
        {
            const string value = "\n:: ALL Equipments ::\n";
            Console.WriteLine(value.ToString());
            shopL?.GetAllSkiEquipments()
                .ToList()
                .ForEach(x => Console.WriteLine(x.ToString()));

            Console.ReadLine();
        }

        /// <summary>
        /// This method lists one of the customers.
        /// </summary>
        /// <param name="customerLogic">Logic for Customers repository.</param>
        public static void GetOneCustomer(CustomerLogic customerLogic)
        {
            int id = IntParse(Enter.ToString());

            bool valid = false;
            try
            {
                customerLogic?.GetCustomerById(id);
                valid = true;
            }
            catch (ArgumentException)
            {
                Console.WriteLine(Other.ToString());
                GetOneCustomer(customerLogic);
            }

            if (valid)
            {
                Console.WriteLine(Selected.ToString());

                Console.WriteLine(customerLogic?.GetCustomerById(id).ToString());
            }

            Console.ReadLine();
        }

        /// <summary>
        /// This method lists one of the Orders.
        /// </summary>
        /// <param name="shopLogic">Logic for Orders repository and SkiEqupments repository.</param>
        public static void GetOneOrder(ShopLogic shopLogic)
        {
            int id = IntParse(Enter.ToString());

            bool valid = false;
            try
            {
                shopLogic?.GetOrderById(id);
                valid = true;
            }
            catch (ArgumentException)
            {
                Console.WriteLine(Other.ToString());
                GetOneOrder(shopLogic);
            }

            if (valid)
            {
                Console.WriteLine(Selected.ToString());

                Console.WriteLine(shopLogic?.GetOrderById(id).ToString());
            }

            Console.ReadLine();
        }

        /// <summary>
        /// This method lists one of the Ski equipments.
        /// </summary>
        /// <param name="shopLogic">Logic for Orders repository and SkiEqupments repository.</param>
        public static void GetOneEquipment(ShopLogic shopLogic)
        {
            int id = IntParse(Enter.ToString());
            bool valid = false;
            try
            {
                shopLogic?.GetSkiEquipmentsById(id);
                valid = true;
            }
            catch (ArgumentException)
            {
                Console.WriteLine(Other.ToString());
                GetOneEquipment(shopLogic);
            }

            if (valid)
            {
                Console.WriteLine(Selected.ToString());

                Console.WriteLine(shopLogic?.GetSkiEquipmentsById(id).ToString());
            }

            Console.ReadLine();
        }

        /// <summary>
        /// This lists the password changing method.
        /// </summary>
        /// <param name="customerLogic">Logic for Customers repository.</param>
        public static void ChangePassword(CustomerLogic customerLogic)
        {
            int id = IntParse(Enter.ToString());
            bool valid = false;
            try
            {
                customerLogic?.GetCustomerById(id);
                valid = true;
            }
            catch (ArgumentException)
            {
                Console.WriteLine(Other.ToString());
            }

            if (valid)
            {
                const string Npw = "Enter new password here: ";
                Console.WriteLine(Npw.ToString());

                string password = Console.ReadLine();

                customerLogic?.ChangePassword(id, password);

                Console.WriteLine(Saved.ToString());
            }

            Console.ReadLine();
        }

        /// <summary>
        /// This lists the price changing method.
        /// </summary>
        /// <param name="shopLogic">Logic for Orders repository and SkiEqupments repository.</param>
        public static void ChangePrice(ShopLogic shopLogic)
        {
            int id = IntParse(Enter.ToString());
            bool valid = false;
            try
            {
                shopLogic?.GetOrderById(id);
                valid = true;
            }
            catch (ArgumentException)
            {
                Console.WriteLine(Other.ToString());
            }

            if (valid)
            {
                const string Np = "Enter new price here: ";

                int price = IntParse(Np.ToString());

                shopLogic?.ChangePrice(id, price);

                Console.WriteLine(Saved.ToString());
            }

            Console.ReadLine();
        }

        /// <summary>
        /// This lists the payment method changing method.
        /// </summary>
        /// <param name="shopLogic">Logic for Orders repository and SkiEqupments repository.</param>
        public static void ChangePayment(ShopLogic shopLogic)
        {
            int id = IntParse(Enter.ToString());
            bool valid = false;
            try
            {
                shopLogic?.GetSkiEquipmentsById(id);
                valid = true;
            }
            catch (ArgumentException)
            {
                Console.WriteLine(Other.ToString());
            }

            if (valid)
            {
                const string Npm = "Enter new payment method here: ";
                Console.WriteLine(Npm.ToString());

                string payment = Console.ReadLine();

                shopLogic?.ChangePayment(id, payment);

                Console.WriteLine(Saved.ToString());
            }

            Console.ReadLine();
        }

        /// <summary>
        /// It converts the string value into integer.
        /// </summary>
        /// <returns>An integer.</returns>
        private static int IntParse(string outString)
        {
            bool validInt = false;
            string inp = string.Empty;

            while (validInt == false)
            {
                Console.WriteLine(outString);
                inp = Console.ReadLine();
                bool success = int.TryParse(inp, out int number);
                if (success)
                {
                    validInt = true;
                }
                else
                {
                    string outp = "Enter an integer value!";
                    Console.WriteLine(outp.ToString());
                }
            }

            return int.Parse(inp, new CultureInfo("en-US"));
        }
    }
}
