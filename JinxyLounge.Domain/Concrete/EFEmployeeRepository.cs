using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JinxyLounge.Domain.Abstract;
using JinxyLounge.Domain.Models;

namespace JinxyLounge.Domain.Concrete
{
    public class EFEmployeeRepository : IEmployeeRepository 
    {
        private readonly EFDbContext context;
        public EFEmployeeRepository()
        {
            context = new EFDbContext();
        }

        public IEnumerable<Employee> GetAllEmployees
        {
            get { return context.Employees; }
        }


        public IEnumerable<Employee> SearchEmployee(string searchTerm)
        {

            var employees = context.Employees.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                employees = employees.Where(a => a.Name.ToLower().Contains(searchTerm.ToLower()));
            }

            return employees.ToList();
        }

        public void SaveEmployee(Employee employee)
        {
            context.Employees.Add(employee);

            context.SaveChanges();
        }

        public void UpdateEmployee(Employee employee)
        {
            var local = context.Set<Employee>()
                         .Local
                         .FirstOrDefault(f => f.ID == employee.ID);
            if (local != null)
            {
                context.Entry(local).State = EntityState.Detached;
            }
            context.Entry(employee).State = EntityState.Modified;

            context.SaveChanges();

            //_dbcontext.Entry(employee).State = System.Data.Entity.EntityState.Modified;

            //_dbcontext.SaveChanges();
        }
        public void DeleteEmployee(Employee employee)
        {

            context.Entry(employee).State = System.Data.Entity.EntityState.Deleted;

            context.SaveChanges();
        }

        public Employee GetEmployeeById(int Id)
        {
            return context.Employees.Find(Id);
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
 