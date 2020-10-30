namespace SkiRental.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SkiRental.Data;
    using SkiRental.Repository;

    public class CustomerLogic : ICustomerLogic
    {
        ICustomerRepository customerRepo;

        public CustomerLogic(ICustomerRepository customerRepo)
        {
            this.customerRepo = customerRepo;
        }

        public void ChangePassword(int id, string newPassword)
        {
            customerRepo.ChangePassword(id, newPassword);
        }

        public IList<Customer> GetAllCustomers()
        {
            return customerRepo.GetAll().ToList();
        }

        public Customer GetCustomerById(int id)
        {
            return customerRepo.GetOne(id);
        }
    }
}
