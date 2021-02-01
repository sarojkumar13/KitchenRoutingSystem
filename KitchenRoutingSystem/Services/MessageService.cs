using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace KitchenRoutingSystem.Services
{
	public class MessageService : IMessageService
	{
		private readonly IConfiguration _config;
		private readonly ILogger<MessageService> _logger;
		private readonly ITopicClient _client;

		public MessageService(IConfiguration config, ILogger<MessageService> logger, ITopicClient client)
		{
			_config = config;
			_logger = logger;
			_client = client;

		}

		public async Task SendOrderToKitchenAsync<T>(T order, string filter)
		{
			try
			{
				string orderQueue = JsonSerializer.Serialize(order);
				Message message = new Message(Encoding.UTF8.GetBytes(orderQueue));
				message.Label = filter;

				await _client.SendAsync(message);
			}

			catch (Exception e)
			{
				_logger.LogError(e.Message);
			}
		}
	}
}
