using Expert.Domain.DTOs;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Text.Json;

namespace Expert.Infrastructure.Payments
{
    public class PaymentService(IHttpClientFactory httpCLientFactory, IConfiguration configuration) : IPaymentService
    {
        private IHttpClientFactory _httpCLientFactory = httpCLientFactory;
        private readonly string _paymentsBaseUrl = configuration.GetSection("Services:Payments").Value;

        public async Task<bool> ProcessPayment(PaymentInfoDto paymentInfoDto)
        {
            var url = $"{_paymentsBaseUrl}/api/payments";

            var paymentInfoJson = JsonSerializer.Serialize(paymentInfoDto);

            var paymentInfoContent = new StringContent(paymentInfoJson, Encoding.UTF8, "application/json");

            var httpClient = _httpCLientFactory.CreateClient("Payments");

            var response = await httpClient.PostAsync(url, paymentInfoContent);

            return response.IsSuccessStatusCode;

        }
    }
}
