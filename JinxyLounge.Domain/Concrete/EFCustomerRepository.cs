using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JinxyLounge.Domain.Abstract;
using JinxyLounge.Domain.Entities;

namespace JinxyLounge.Domain.Concrete
{
    public class EFCustomerRepository : ICustomerRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Customer> GetAllCustomers()
        {
            { return context.Customers; }
        }
        public void DeleteCustomer(Customer customer)
        {
            context.Entry(customer).State = System.Data.Entity.EntityState.Deleted;

            context.SaveChanges();
        }

        public Customer GetCustomerById(int Id)
        {
            return context.Customers.Find(Id);
        }

        public void SaveCustomer(Customer customer)
        {
            context.Customers.Add(customer);

            context.SaveChanges();
        }

        public IEnumerable<Customer> SearchCustomer(string searchTerm)
        {
            var customer = context.Customers.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                customer = customer.Where(a => a.LastName.ToLower().Contains(searchTerm.ToLower()));
            }

            return customer.ToList();
        }

        public void UpdateCustomer(Customer customer)
        {
            var local = context.Set<Payment>()
                        .Local
                        .FirstOrDefault(f => f.Id == customer.Id);
            if (local != null)
            {
                context.Entry(local).State = EntityState.Detached;
            }
            context.Entry(customer).State = EntityState.Modified;

            context.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
