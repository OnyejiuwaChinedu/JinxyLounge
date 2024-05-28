using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JinxyLounge.Domain.Abstract;

namespace JinxyLounge.Domain.Concrete
{
    public class EFInvoiceRepository : IInvoiceRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Invoice> GetAllInvoice()
        {
            { return context.Invoices; }
        }

        public void DeleteInvoice(Invoice invoice)
        {
            context.Entry(invoice).State = System.Data.Entity.EntityState.Deleted;

            context.SaveChanges();
        }

        public Invoice GetInvoiceById(int Id)
        {
            return context.Invoices.Find(Id);
        }

        public void SaveInvoice(Invoice invoice)
        {
            context.Invoices.Add(invoice);

            context.SaveChanges();
        }

        public IEnumerable<Invoice> SearchInvoice(string searchTerm)
        {
            var invoice = context.Invoices.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                invoice = invoice.Where(a => a.Name.ToLower().Contains(searchTerm.ToLower()));
            }

            return invoice.ToList();
        }

        public void UpdateInvoice(Invoice invoice)
        {
            var local = context.Set<Invoice>()
                         .Local
                         .FirstOrDefault(f => f.Id == invoice.Id);
            if (local != null)
            {
                context.Entry(local).State = EntityState.Detached;
            }
            context.Entry(invoice).State = EntityState.Modified;

            context.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
