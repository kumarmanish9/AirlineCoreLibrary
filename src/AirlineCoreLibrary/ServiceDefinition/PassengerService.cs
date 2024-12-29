using AirlineCoreLibrary.Model;
using AirlineCoreLibrary.Service;
using AirlineCoreLibrary.Utility;

namespace AirlineCoreLibrary.ServiceDefinition
{
    /// <summary>
    /// Provides services for retrieving passenger information.
    /// </summary>
    public class PassengerService(IDatabaseService databaseService) : IPassengerService
    {
        /// <inheritdoc />
        public async Task<List<PassengerCompenation>?> GetPassengers(string flightKey)
        {
            try
            {
                var passengers = await databaseService.GetPassengersAsync(flightKey);
                return passengers;
            }
            catch (Exception ex)
            {
                AppLogger.LogError("An error occurred while retrieving passengers.", ex);
                return null;
            }
        }
    }
}
