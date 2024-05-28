using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JinxyLounge.Domain.Entities;

namespace JinxyLounge.Domain.Abstract
{
    public interface IPaymentRepository
    {
        IEnumerable<Payment> GetAllPayment();
        IEnumerable<Payment> SearchPayment(string searchTerm);
        void SavePayment(Payment payment);
        void UpdatePayment(Payment payment);
        void DeletePayment(Payment payment);
        Payment GetPaymentById(int Id);
        void Dispose();
      
    }
}
