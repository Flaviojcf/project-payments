using Payments.API.Models;
using Payments.API.Services;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace Payments.API.Consumers
{
    public class ProcessPaymentConsumer : BackgroundService
    {
        private readonly IConnection _connection;
        private readonly IModel _model;
        private readonly IServiceProvider _serviceProvider;
        private const string QUEUE_NAME = "Payments";
        private const string PAYMENT_APPROVED_QUEUE = "PaymentsApproved";

        public ProcessPaymentConsumer(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

            var factory = new ConnectionFactory
            {
                HostName = "localhost"
            };

            _connection = factory.CreateConnection();

            _model = _connection.CreateModel();

            _model.QueueDeclare(queue: QUEUE_NAME, durable: false,
                                exclusive: false, autoDelete: false, arguments: null);

            _model.QueueDeclare(queue: PAYMENT_APPROVED_QUEUE, durable: false,
                         exclusive: false, autoDelete: false, arguments: null);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_model);

            consumer.Received += (sender, eventArgs) =>
            {
                var byteArray = eventArgs.Body.ToArray();
                var paymentInfoJson = Encoding.UTF8.GetString(byteArray);

                var paymentInfo = JsonSerializer.Deserialize<PaymentInfoInputModel>(paymentInfoJson);

                ProcesssPayment(paymentInfo);

                var paymentApproved = new PaymentApprovedIntegrationEvent(paymentInfo.IdProject);
                var paymentApprovedJson = JsonSerializer.Serialize(paymentApproved);
                var paymentApprovedBytes = Encoding.UTF8.GetBytes(paymentApprovedJson);

                _model.BasicPublish(exchange: "", routingKey: PAYMENT_APPROVED_QUEUE,
                                    basicProperties: null, body: paymentApprovedBytes);

                _model.BasicAck(eventArgs.DeliveryTag, false);
            };

            _model.BasicConsume(QUEUE_NAME, false, consumer);

            return Task.CompletedTask;
        }

        public void ProcesssPayment(PaymentInfoInputModel paymentInfo)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var paymentService = scope.ServiceProvider.GetRequiredService<IPaymentService>();

                paymentService.Process(paymentInfo);
            }
        }
    }
}
