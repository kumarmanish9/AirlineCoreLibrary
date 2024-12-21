using AirlineCoreLibrary.Model;
using AirlineCoreLibrary.Service;

namespace AirlineCoreLibrary.ServiceDefinition
{
    /// <summary>
    /// Provides services for retrieving flight information.
    /// </summary>
    public class FlightService : IFlightService
    {
        /// <inheritdoc />
        public async Task<List<Flight>?> GetFlights()
        {
            try
            {
                var flights = new List<Flight>
                {
                    new() { FlightNumber = "AB123", Departure = "DEL", Arrival = "JFK", ScheduledDate = "2024-11-01 08:30 AM", NumberOfPax = "150" },
                    new() { FlightNumber = "CD456", Departure = "LAX", Arrival = "ORD", ScheduledDate = "2024-11-01 09:30 AM", NumberOfPax = "180" },
                    new() { FlightNumber = "EF789", Departure = "ORD", Arrival = "SFO", ScheduledDate = "2024-11-01 10:30 AM", NumberOfPax = "200" },
                    new() { FlightNumber = "GH012", Departure = "SFO", Arrival = "MIA", ScheduledDate = "2024-11-01 11:30 AM", NumberOfPax = "130" },
                    new() { FlightNumber = "IJ345", Departure = "MIA", Arrival = "LAX", ScheduledDate = "2024-11-01 12:30 PM", NumberOfPax = "220" },
                    new() { FlightNumber = "KL678", Departure = "DFW", Arrival = "SEA", ScheduledDate = "2024-11-01 01:30 PM", NumberOfPax = "170" },
                    new() { FlightNumber = "MN901", Departure = "SEA", Arrival = "ATL", ScheduledDate = "2024-11-01 02:30 PM", NumberOfPax = "160" },
                    new() { FlightNumber = "ST890", Departure = "DEN", Arrival = "DCA", ScheduledDate = "2024-11-01 05:30 PM", NumberOfPax = "150" },
                    new() { FlightNumber = "UV123", Departure = "ATL", Arrival = "BOS", ScheduledDate = "2024-11-01 06:30 PM", NumberOfPax = "220" },
                    new() { FlightNumber = "WX456", Departure = "DCA", Arrival = "BOS", ScheduledDate = "2024-11-01 07:30 PM", NumberOfPax = "210" },
                    new() { FlightNumber = "YZ789", Departure = "BOS", Arrival = "JFK", ScheduledDate = "2024-11-01 08:30 PM", NumberOfPax = "180" },
                    new() { FlightNumber = "IJ246", Departure = "MIA", Arrival = "SEA", ScheduledDate = "2024-11-02 12:30 PM", NumberOfPax = "190" },
                    new() { FlightNumber = "KL357", Departure = "SEA", Arrival = "DFW", ScheduledDate = "2024-11-02 01:30 PM", NumberOfPax = "160" },
                };


                return flights;
            }
            catch
            {
                await Task.Delay(1000);
                return null;
            }
        }
    }
}
