using Expert.Domain.DTOs;
using Expert.Domain.Services;
using System.Text;
using System.Text.Json;

namespace Expert.Infrastructure.Payments
{
    public class PaymentService(IMessageBusService messageBusService) : IPaymentService
    {
        private readonly IMessageBusService _messageBusService = messageBusService;
        private const string QUEUE_NAME = "Payments";

        public void ProcessPayment(PaymentInfoDto paymentInfoDto)
        {

            var paymentInfoJson = JsonSerializer.Serialize(paymentInfoDto);

            var paymentInfoBytes = Encoding.UTF8.GetBytes(paymentInfoJson);

            _messageBusService.Publish(QUEUE_NAME, paymentInfoBytes);
        }
    }
}
