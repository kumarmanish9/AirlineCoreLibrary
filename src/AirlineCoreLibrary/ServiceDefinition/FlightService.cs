using AirlineCoreLibrary.Model;
using AirlineCoreLibrary.Service;
using AirlineCoreLibrary.Utility;

namespace AirlineCoreLibrary.ServiceDefinition
{
    /// <summary>
    /// Provides services for retrieving flight information.
    /// </summary>
    public class FlightService(IDatabaseService databaseService): IFlightService
    {
        /// <inheritdoc />
        public async Task<List<Flight>?> GetFlights()
        {
            try
            {
                var flights = await databaseService.GetFlightsAsync();
                return flights;
            }
            catch(Exception ex)
            {
                AppLogger.LogWarning("An error occurred while retrieving flights.", ex);
                return null;
            }
        }
    }
}
