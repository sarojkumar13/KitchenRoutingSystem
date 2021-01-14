using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KitchenRoutingSystem
{
	public class Kitchen
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public ICollection<Item> Items { get; set; }
	}

	enum KitchenType
	{
		Fries = 1,
		Drink = 2,
		Grill = 3,
		Salad = 4,
		Desert = 5
	};
}
