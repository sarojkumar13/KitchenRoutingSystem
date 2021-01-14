using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KitchenRoutingSystem.Services
{
    public class RoutingToKitchenService : IRoutingToKitchenService
    {
        private readonly IMessageService _message;
        // This can move to app settings file
        private const string topicName = "orderrouting";
        public RoutingToKitchenService(IMessageService message)
        {
            _message = message;
        }

        public async Task RouteOrder(Order order)
        {
            foreach(var orderitem in order?.OrderDetails)
            {

                await _message.SendOrderToKitchenAsync<OrderDetail>(orderitem, topicName, orderitem.Item.Kitchen.Name);
            }
        }
    }
}
