namespace AirlineCoreLibrary.Service
{
    public interface IEventProcessor
    {
        Task ProcessFlightEventAsync();
    }
}
