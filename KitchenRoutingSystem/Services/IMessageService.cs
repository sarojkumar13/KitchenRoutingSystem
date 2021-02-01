using System.Threading.Tasks;

namespace KitchenRoutingSystem.Services
{
    public interface IMessageService
    {
        Task SendOrderToKitchenAsync<T>(T order, string filter);
    }
}