using AirlineCoreLibrary.Model;
using AirlineCoreLibrary.Service;
using AirlineCoreLibrary.Utility;

namespace AirlineCoreLibrary.ServiceDefinition
{
    /// <summary>
    /// Provides database-related operations for managing flights and passengers.
    /// </summary>
    internal class DatabaseService() : IDatabaseService
    {
        /// <inheritdoc />
        public Task SaveFlightAsync(Flight flight)
        {
            AppLogger.LogInfo("Saving flight", flight);
            return Task.CompletedTask;
        }

        /// <inheritdoc />
        public Task SavePassengerAsync(Passenger passenger)
        {
            AppLogger.LogInfo("Saving passenger", passenger);
            return Task.CompletedTask;
        }

        /// <inheritdoc />
        public Task UpdateFlightAsync(Flight flight)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task UpdatePassengerAsync(Passenger passenger)
        {
            throw new NotImplementedException();
        }
    }
}
