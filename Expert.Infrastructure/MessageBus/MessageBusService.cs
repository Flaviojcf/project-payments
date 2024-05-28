using Expert.Domain.Services;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;

namespace Expert.Infrastructure.MessageBus
{
    public class MessageBusService : IMessageBusService
    {
        private readonly ConnectionFactory _connectionFactory;
        public MessageBusService(IConfiguration configuration)
        {
            _connectionFactory = new ConnectionFactory
            {
                HostName = "localhost",
            };
        }
        public void Publish(string queue, byte[] message)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue, durable: false, exclusive: false,
                                         autoDelete: false, arguments: null);

                    channel.BasicPublish(exchange: "", routingKey: queue,
                                         basicProperties: null, body: message);

                }
            }
        }
    }
}
