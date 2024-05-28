using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JinxyLounge.Domain.Entities;
using JinxyLounge.Domain.Models;

namespace JinxyLounge.Domain.Concrete
{
    public class EFDbContext : DbContext
    {      

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeType> EmployeeTypes { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<ProImage> Images { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }

    }  
}
