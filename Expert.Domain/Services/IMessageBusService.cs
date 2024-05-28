namespace Expert.Domain.Services
{
    public interface IMessageBusService
    {
        void Publish(string queue, byte[] message);
    }
}
