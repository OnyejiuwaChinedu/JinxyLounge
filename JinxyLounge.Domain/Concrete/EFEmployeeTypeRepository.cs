using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JinxyLounge.Domain.Abstract;
using JinxyLounge.Domain.Models;

namespace JinxyLounge.Domain.Concrete
{
    public class EFEmployeeTypeRepository: IEmployeeTypeRepository
    {
        private readonly EFDbContext context;
        public EFEmployeeTypeRepository()
        {
            context = new EFDbContext();
        }

        public IEnumerable<EmployeeType> GetAllEmployeeTypes
        {
            get { return context.EmployeeTypes; }
        }

        public IEnumerable<EmployeeType> SearchEmployeeType(string searchTerm)
        {
            var employeeTypes = context.EmployeeTypes.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                employeeTypes = employeeTypes.Where(a => a.TypeName.ToLower().Contains(searchTerm.ToLower()));
            }

            return employeeTypes.ToList();
        }

        public void SaveEmployeeType(EmployeeType employeeType)
        {
            context.EmployeeTypes.Add(employeeType);

            context.SaveChanges();
        }

        public void UpdateEmployeeType(EmployeeType employeeType)
        {

            context.Entry(employeeType).State = System.Data.Entity.EntityState.Modified;

            context.SaveChanges();
        }
        public void DeleteEmployeeType(EmployeeType employeeType)
        {

            context.Entry(employeeType).State = System.Data.Entity.EntityState.Deleted;

            context.SaveChanges();
        }

        public EmployeeType GetEmployeeTypeById(int Id)
        {
            return context.EmployeeTypes.Find(Id);
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
  