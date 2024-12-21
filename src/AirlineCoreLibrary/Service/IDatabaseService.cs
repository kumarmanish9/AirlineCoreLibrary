using AirlineCoreLibrary.Model;

namespace AirlineCoreLibrary.Service
{
    public interface IDatabaseService
    {
        Task SaveFlightAsync(Flight flight);
        Task UpdateFlightAsync(Flight flight);

        Task SavePassengerAsync(Passenger passenger);
        Task UpdatePassengerAsync(Passenger passenger);
    }
}
