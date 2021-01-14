using System.Threading.Tasks;

namespace KitchenRoutingSystem.Services
{
    public interface IRoutingToKitchenService
    {
        Task RouteOrder(Order order);
    }
}