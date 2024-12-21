using AirlineCoreLibrary.Model;
using AirlineCoreLibrary.Service;
using AirlineCoreLibrary.Utility;

namespace AirlineCoreLibrary.ServiceDefinition
{
    internal class DatabaseService() : IDatabaseService
    {
        public Task SaveFlightAsync(Flight flight)
        {
            AppLogger.LogInfo("Saving flight", flight);
            return Task.CompletedTask;
        }

        public Task SavePassengerAsync(Passenger passenger)
        {
            AppLogger.LogInfo("Saving passenger", passenger);
            return Task.CompletedTask;
        }

        public Task UpdateFlightAsync(Flight flight)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePassengerAsync(Passenger passenger)
        {
            throw new NotImplementedException();
        }
    }
}
