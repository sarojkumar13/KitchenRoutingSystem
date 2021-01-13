using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KitchenRoutingSystem
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int KitchenId { get; set; }
        public virtual Kitchen Kitchen { get; set; }
    }
}
