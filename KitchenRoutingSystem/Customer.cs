using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KitchenRoutingSystem
{
    // We can also use the Table Number in case of Sitting Customer
    public class Customer
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
