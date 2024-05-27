using Expert.Domain.DTOs;

namespace Expert.Infrastructure.Payments
{
    public interface IPaymentService
    {
        Task<bool> ProcessPayment(PaymentInfoDto paymentInfoDto);
    }
}
