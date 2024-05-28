using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JinxyLounge.Domain.Entities;

namespace JinxyLounge.Domain.Abstract
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAllCustomers();
        IEnumerable<Customer> SearchCustomer(string searchTerm);
        void SaveCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(Customer customer);
        Customer GetCustomerById(int Id);
        void Dispose();

    }
}
