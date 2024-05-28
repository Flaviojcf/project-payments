namespace Expert.Domain.IntegrationEvents
{
    public class PaymentApprovedntegrationEvent(int idProject)
    {
        public int IdProject { get; set; } = idProject;
    }
}
