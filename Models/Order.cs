using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bartender_App.Models
{
    public class Order
    {
        public int Id{ get; set; }
        public string OrderName { get; set; }
        public string OrderId { get; set; }
        public double Total { get; set; }
    }
}
