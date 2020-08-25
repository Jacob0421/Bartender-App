using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bartender_App.Models
{
    public class Order
    {
        [HiddenInput]
        public int Id{ get; set; }
        [Display(Name = "Name on Order")]
        [Required]
        public string OrderName { get; set; }
        [Required]
        [Display(Name = "Ordered Drink")]
        public string DrinkOrdered { get; set; }
        [HiddenInput]
        public string Total { get; set; }
        [HiddenInput]
        public bool Ready { get; set; }
        [HiddenInput]
        public bool PickedUp { get; set; }

    }
}
