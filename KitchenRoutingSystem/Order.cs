using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KitchenRoutingSystem
{
    public class Order
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
