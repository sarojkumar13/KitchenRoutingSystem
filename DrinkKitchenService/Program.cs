using Microsoft.Azure.ServiceBus;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DrinkKitchenService
{
    class Program
    {
            const string connectionString = "Replace with Azure service bus connection string";
            const string drink = "Replace with subscription name";
            const string topicName = "replace with topic name";
            static ISubscriptionClient subscriptionClient;
            static async Task Main(string[] args)
            {
                subscriptionClient = new SubscriptionClient(connectionString: connectionString, topicPath: topicName, subscriptionName: drink);

                var messageHandlerOptions = new MessageHandlerOptions(ExceptionReceivedHandler)
                {
                    MaxConcurrentCalls = 1,
                    AutoComplete = false
                };

                subscriptionClient.RegisterMessageHandler(ProcessMessagesAsync, messageHandlerOptions);

                Console.ReadLine();

                await subscriptionClient.CloseAsync();
            }

            private static async Task ProcessMessagesAsync(Message message, CancellationToken token)
            {
                var jsonString = Encoding.UTF8.GetString(message.Body);
                Console.WriteLine(jsonString);

                await subscriptionClient.CompleteAsync(message.SystemProperties.LockToken);
            }

            private static Task ExceptionReceivedHandler(ExceptionReceivedEventArgs arg)
            {
                Console.WriteLine($"Message handler exception: { arg.Exception }");
                return Task.CompletedTask;
            }
        }
    }
