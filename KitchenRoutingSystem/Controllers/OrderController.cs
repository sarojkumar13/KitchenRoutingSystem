using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KitchenRoutingSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace KitchenRoutingSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
       
        private readonly IRoutingToKitchenService _kitchenRoutingService;

        public OrderController(IRoutingToKitchenService kitchenRoutingService )
        {
            _kitchenRoutingService = kitchenRoutingService;
        }

        [HttpPost("Order")]
        public async Task<IActionResult> ProcessOrder(Order order)
        {
            await _kitchenRoutingService.RouteOrder(order);

            return Ok("Order Sent to Kitchen");
        }
    }
}
