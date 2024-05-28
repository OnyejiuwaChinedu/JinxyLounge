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
    public class EFOrderRepository : IOrderRepository
    {
        private EFDbContext context = new EFDbContext();

        //public IEnumerable<Order> IOrderRepository.GetAllOrder => throw new NotImplementedException();

        public IEnumerable<Order> GetAllOrder()
        {
            { return context.Orders; }
        }

        public void DeleteOrder(Order order)
        {

            context.Entry(order).State = System.Data.Entity.EntityState.Deleted;

            context.SaveChanges();
        }

        public Order GetOrderById(int Id)
        {
            return context.Orders.Find(Id);
        }

        public void SaveOrder(Order order)
        {
            context.Orders.Add(order);

            context.SaveChanges();
        }

        public IEnumerable<Order> SearchOrder(string searchTerm)
        {
            var order = context.Orders.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                order = order.Where(a => a.Quantity.ToLower().Contains(searchTerm.ToLower()));
            }

            return order.ToList();
        }

        public void UpdateOrder(Order order)
        {
            var local = context.Set<Order>()
                       .Local
                       .FirstOrDefault(f => f.Id == order.Id);
            if (local != null)
            {
                context.Entry(local).State = EntityState.Detached;
            }
            context.Entry(order).State = EntityState.Modified;

            context.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

     
    }
}
