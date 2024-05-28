using Expert.Domain.DTOs;

namespace Expert.Infrastructure.Payments
{
    public interface IPaymentService
    {
        void ProcessPayment(PaymentInfoDto paymentInfoDto);
    }
}
