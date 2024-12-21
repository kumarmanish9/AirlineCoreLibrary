using AirlineCoreLibrary.Model;

namespace AirlineCoreLibrary.Service
{
    public interface IPassengerService
    {
        Task<List<Passenger>?> GetPassenger(Flight? flight);
        Task<List<Passenger>?> GetPassengerV2(Flight? flight);
    }
}
