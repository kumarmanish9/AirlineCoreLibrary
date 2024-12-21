using AirlineCoreLibrary.Model;

namespace AirlineCoreLibrary.Service
{
    public interface IFlightService
    {
        Task<List<Flight>?> GetFlights();
    }
}
