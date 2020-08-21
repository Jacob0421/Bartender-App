using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bartender_App.Models
{
    interface IOrderRepository
    {
        Order GetOrder(int orderId);
        IEnumerable<Order> GetOrders();
        Order AddOrder(Order newOrder);
        Order DeleteOrder(int id);
        Order EditOrder(Order orderChanges);
    }
}
