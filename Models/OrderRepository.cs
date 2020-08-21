using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bartender_App.Models
{
    public class OrderRepository : IOrderRepository
    {
        public Order AddOrder(Order newOrder)
        {
            throw new NotImplementedException();
        }

        public Order DeleteOrder(int id)
        {
            throw new NotImplementedException();
        }

        public Order EditOrder(Order orderChanges)
        {
            throw new NotImplementedException();
        }

        public Order GetOrder(int orderId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetOrders()
        {
            throw new NotImplementedException();
        }
    }
}
