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
    public class EFPaymentRepository : IPaymentRepository
    {
        private EFDbContext context = new EFDbContext();
        //public IEnumerable<Payment> GetAllPayment => throw new NotImplementedException();
        public IEnumerable<Payment> GetAllPayment()
        {
            { return context.Payments; }
        }

        public void DeletePayment(Payment payment)
        {

            context.Entry(payment).State = System.Data.Entity.EntityState.Deleted;

            context.SaveChanges();
        }
     
        public Payment GetPaymentById(int Id)
        {
            return context.Payments.Find(Id);
        }

        public void SavePayment(Payment payment)
        {

            context.Payments.Add(payment);

            context.SaveChanges();
        }

        public IEnumerable<Payment> SearchPayment(string searchTerm)
        {
            var payment = context.Payments.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                payment = payment.Where(a => a.Description.ToLower().Contains(searchTerm.ToLower()));
            }

            return payment.ToList();
        }

        public void UpdatePayment(Payment payment)
        {
            var local = context.Set<Payment>()
                        .Local
                        .FirstOrDefault(f => f.Id == payment.Id);
            if (local != null)
            {
                context.Entry(local).State = EntityState.Detached;
            }
            context.Entry(payment).State = EntityState.Modified;

            context.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        
    }
}
