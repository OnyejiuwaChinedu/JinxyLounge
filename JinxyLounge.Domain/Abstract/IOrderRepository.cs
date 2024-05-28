using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JinxyLounge.Domain.Entities;

namespace JinxyLounge.Domain.Abstract
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAllOrder();
        IEnumerable<Order> SearchOrder(string searchTerm);
        void SaveOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(Order order);
        Order GetOrderById(int Id);
        void Dispose();
    }
}
