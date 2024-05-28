namespace Payments.API.Models
{
    public class PaymentApprovedIntegrationEvent(int idProject)
    {
        public int IdProject { get; set; } = idProject;
    }
}
