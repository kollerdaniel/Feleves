// <copyright file="MenuMethods.cs" company="OXDRAP">
// Copyright (c) OXDRAP. All rights reserved.
// </copyright>

namespace SkiRental.Program
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using SkiRental.Logic;
    using SkiRental.Repository;

    /// <summary>
    /// This is a class for the methods that menu uses.
    /// </summary>
    public static class MenuMethods
    {
        private const string Enter = "Enter id here: ";
        private const string PressEnter = "Press Enter";
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
                Console.WriteLine(Selected.ToString());
                Console.WriteLine(customerLogic?.GetCustomerById(id).ToString());
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
                shopLogic?.GetSkiEquipmentsById(id);
                valid = true;
            }
            catch (ArgumentException)
            {
                Console.WriteLine(Other.ToString());
            }

            if (valid)
            {
                Console.WriteLine(Selected.ToString());

                Console.WriteLine(shopLogic?.GetSkiEquipmentsById(id).ToString());
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
                shopLogic?.GetOrderById(id);
                valid = true;
            }
            catch (ArgumentException)
            {
                Console.WriteLine(Other.ToString());
            }

            if (valid)
            {
                Console.WriteLine(Selected.ToString());

                Console.WriteLine(shopLogic?.GetOrderById(id).ToString());
                Console.WriteLine(PressEnter.ToString());
                valid = false;
                string payment = string.Empty;
                do
                {
                    const string Npm = "Enter new payment method here: (Credit Card/PayPal)";
                    payment = Console.ReadLine();
                    Console.WriteLine(Npm.ToString());
                    if (payment == "Credit Card" || payment == "PayPal")
                    {
                        valid = true;
                    }
                }
                while (!valid);

                shopLogic?.ChangePayment(id, payment);

                Console.WriteLine(Saved.ToString());
            }

            Console.ReadLine();
        }

        /// <summary>
        /// This is the customer eraser menu method.
        /// </summary>
        /// <param name="customerLogic">Customer logic class.</param>
        public static void DeleteCustomer(CustomerLogic customerLogic)
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
                bool exists = customerLogic.DeleteCustomer(id);
                if (exists)
                {
                    string print = "Entity deleted.";
                    Console.WriteLine(print.ToString());
                }
                else
                {
                    Console.WriteLine(Other.ToString());
                    id = IntParse(Enter.ToString());
                }
            }

            Console.ReadLine();
        }

        /// <summary>
        /// This is the order eraser menu method.
        /// </summary>
        /// <param name="shopLogic">Logic for Orders repository and SkiEqupments repository.</param>
        public static void DeleteOrder(ShopLogic shopLogic)
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
                bool exists = shopLogic.DeleteOrder(id);
                if (exists)
                {
                    string print = "Entity deleted.";
                    Console.WriteLine(print.ToString());
                }
                else
                {
                    Console.WriteLine(Other.ToString());
                    id = IntParse(Enter.ToString());
                }
            }

            Console.ReadLine();
        }

        /// <summary>
        /// This is the order eraser menu method.
        /// </summary>
        /// <param name="shopLogic">Logic for Orders repository and SkiEqupments repository.</param>
        public static void DeleteEquipment(ShopLogic shopLogic)
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
                bool exists = shopLogic.DeleteEquipment(id);
                if (exists)
                {
                    string print = "Entity deleted.";
                    Console.WriteLine(print.ToString());
                }
                else
                {
                    Console.WriteLine(Other.ToString());
                    id = IntParse(Enter.ToString());
                }
            }

            Console.ReadLine();
        }

        /// <summary>
        /// It asks about customer datas.
        /// </summary>
        /// <param name="customer">Customer logic.</param>
        public static void InsertCustomer(CustomerLogic customer)
        {
            customer?.GetAllCustomers().ToList().ForEach(x => Console.WriteLine(x));
            string firstname = string.Empty;
            do
            {
                ToConsole("\nEnter your firstname:");
                firstname = Console.ReadLine();
            }
            while (firstname == null);

            string lastname = string.Empty;
            do
            {
                ToConsole("\nEnter your lastname:");
                lastname = Console.ReadLine();
            }
            while (lastname == null);

            string password = string.Empty;
            do
            {
                ToConsole("\nEnter your password:");
                password = Console.ReadLine();
            }
            while (password == null);

            string difficulty = string.Empty;
            do
            {
                ToConsole("\nEnter your difficulty: (beginner / advanced / pro)");
                difficulty = Console.ReadLine();
            }
            while (difficulty == null);

            int size = IntParse("\nEnter your size");
            DateTime birthdate = DateParse("\nEnter your birthdate: (YYYY.MM.DD)");
            int postcode = IntParse("\nEnter your postcode: ");

            string email = string.Empty;
            do
            {
                ToConsole("\nEnter your email: ");
                email = Console.ReadLine();
            }
            while (email == null);

            customer?.CreateCustomer(new Data.Customer() { FirstName = firstname, LastName = lastname, Password = password, Difficulty = difficulty, Size = size, Birthdate = birthdate, Postcode = postcode, Email = email });
            ToConsole("\nNew customer succesfully created!");
            ListAllC(customer);
        }

        /// <summary>
        /// It asks about order datas.
        /// </summary>
        /// <param name="shop">Logic for Orders repository and SkiEqupments repository.</param>
        public static void InsterOrder(ShopLogic shop)
        {
            shop?.GetAllOrders().ToList().ForEach(x => Console.WriteLine(x));

            string payment = string.Empty;
            do
            {
                ToConsole("\nEnter payment:");
                payment = Console.ReadLine();
            }
            while (payment == "Credit Card" || payment == "PayPal");

            DateTime firstdate = DateParse("\nEnter first date:");
            DateTime lastdate = DateParse("\nEnter last date:");
            int promotion = IntParse("\nEnter promotion:");
            string validS = string.Empty;
            bool valid = false;
            do
            {
                ToConsole("\nEnter payment status: (y/n)");
                validS = Console.ReadLine();
            }
            while (validS != "y" & validS != "n");
            if (validS == "y")
            {
                valid = true;
            }

            int customerID = IntParse("\nEnter customer's ID: ");
            shop?.CreateOrder(new Data.Order() { CustomerId = customerID, Payment = payment, FirstDate = firstdate, LastDate = lastdate, Promotion = promotion, CustomerPaid = valid });
            ToConsole("\nNew order successfully created!");
            ListAllO(shop);
        }

        /// <summary>
        /// It asks about equipment datas.
        /// </summary>
        /// <param name="shop">Logic for Orders repository and SkiEqupments repository.</param>
        public static void InsterEquipment(ShopLogic shop)
        {
            shop?.GetAllSkiEquipments().ToList().ForEach(x => Console.WriteLine(x));

            int orderID = IntParse("\nEnter order's ID: ");

            string name = string.Empty;
            do
            {
                ToConsole("\nEnter name: ");
                name = Console.ReadLine();
            }
            while (name == null);

            string manufacturer = string.Empty;
            do
            {
                ToConsole("\nEnter manufacturer: ");
                manufacturer = Console.ReadLine();
            }
            while (manufacturer == null);

            string difficulty = string.Empty;
            do
            {
                ToConsole("\nEnter difficulty: (beginner / advanced / pro)");
                difficulty = Console.ReadLine();
            }
            while (difficulty == null);

            int price = IntParse("\nEnter price:");
            int size = IntParse("\nEnter size:");
            string validS = string.Empty;
            bool valid = false;
            do
            {
                ToConsole("\nEnter payment status: (y/n)");
                validS = Console.ReadLine();
            }
            while (validS != "y" & validS != "n");
            if (validS == "y")
            {
                valid = true;
            }

            shop?.CreateEquipment(new Data.SkiEquipments() { OrderId = orderID, Name = name, Manufacturer = manufacturer, Difficulty = difficulty, Price = price, Size = size, Status = valid });
        }

        /// <summary>
        /// It lists all the Head skis for which they have already been paid.
        /// </summary>
        /// <param name="shopLogic">Logic for Orders repository and SkiEqupments repository.</param>
        public static void PaidHead(ShopLogic shopLogic)
        {
            foreach (var item in shopLogic?.PaidHead())
            {
                Console.WriteLine(item);
                Console.ReadLine();
            }
        }

        /// <summary>
        /// Writes out with task, all the Head skis for which they have already been paid.
        /// </summary>
        /// <param name="shopLogic">Logic for Orders repository and SkiEqupments repository.</param>
        public static void PaidHeadAsync(ShopLogic shopLogic)
        {
            var task = shopLogic?.PaidHeadAsync();
            task.Wait();
            foreach (var item in task.Result)
            {
                Console.WriteLine(item);
                Thread.Sleep(500);
            }

            Console.ReadLine();
        }

        /// <summary>
        /// It lists all the skis, that have promotion.
        /// </summary>
        /// <param name="shopLogic">Logic for Orders repository and SkiEqupments repository.</param>
        public static void PromotionOver170(ShopLogic shopLogic)
        {
            foreach (var item in shopLogic?.PromotionOver170())
            {
                Console.WriteLine(item);
                Console.ReadLine();
            }
        }

        /// <summary>
        /// Writes out with task, all the skis, that have promotion.
        /// </summary>
        /// <param name="shopLogic">Logic for Orders repository and SkiEqupments repository.</param>
        public static void PromotionOver170Async(ShopLogic shopLogic)
        {
            var task = shopLogic?.PromotionOver170Async();
            task.Wait();
            foreach (var item in task.Result)
            {
                Console.WriteLine(item);
                Thread.Sleep(500);
            }

            Console.ReadLine();
        }

        /// <summary>
        /// Lists all the beginner customers who use credit card.
        /// </summary>
        /// <param name="shopLogic">Logic for Orders repository and SkiEqupments repository.</param>
        public static void BeginnersWithCreditCard(ShopLogic shopLogic)
        {
            foreach (var item in shopLogic?.BeginnersWithCreditCard())
            {
                Console.WriteLine(item);
                Console.ReadLine();
            }
        }

        /// <summary>
        /// Lists with task, all the beginner customers who use credit card.
        /// </summary>
        /// <param name="shopLogic">Logic for Orders repository and SkiEqupments repository.</param>
        public static void BeginnersWithCreditCardAsync(ShopLogic shopLogic)
        {
            var task = shopLogic?.BeginnersWithCreditCardAsync();
            task.Wait();
            foreach (var item in task.Result)
            {
                Console.WriteLine(item);
                Thread.Sleep(500);
            }

            Console.ReadLine();
        }

        /// <summary>
        /// I can avoid Console.Writeline with this method.
        /// </summary>
        /// <param name="outString">A string.</param>
        private static void ToConsole(string outString)
        {
            string outS = outString;
            Console.WriteLine(outS.ToString());
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

        /// <summary>
        /// It converts the string value into DateTime.
        /// </summary>
        /// <returns>An date time.</returns>
        private static DateTime DateParse(string outString)
        {
            bool validDate = false;
            string inp = string.Empty;

            while (validDate == false)
            {
                Console.WriteLine(outString);
                inp = Console.ReadLine();
                bool success = DateTime.TryParse(inp, out DateTime result);
                if (success)
                {
                    validDate = true;
                }
                else
                {
                    string outp = "Enter an integer value!";
                    Console.WriteLine(outp.ToString());
                }
            }

            return DateTime.Parse(inp, new CultureInfo("en-US"));
        }
    }
}
