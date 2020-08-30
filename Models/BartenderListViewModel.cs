using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bartender_App.Models
{
    public class BartenderListViewModel
    {
        public Order ForHeaderNames;
        public IEnumerable<Order> PendingOrders { get; set; }
        public IEnumerable<Order> ReadyOrders { get; set; }
    }
}
