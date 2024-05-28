using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JinxyLounge.Domain.Abstract
{
    public interface IInvoiceRepository
    {
        IEnumerable<Invoice> GetAllInvoice();
        IEnumerable<Invoice> SearchInvoice(string searchTerm);
        void SaveInvoice(Invoice invoice);
        void UpdateInvoice(Invoice invoice);
        void DeleteInvoice(Invoice invoice);
        Invoice GetInvoiceById(int Id);
        void Dispose();

    }
}
