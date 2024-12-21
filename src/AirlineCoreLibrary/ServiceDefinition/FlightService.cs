using AirlineCoreLibrary.Model;
using AirlineCoreLibrary.Service;

namespace AirlineCoreLibrary.ServiceDefinition
{
    public class FlightService : IFlightService
    {
        public async Task<List<Flight>?> GetFlights()
        {
            try
            {
                var flights = new List<Flight>
                {
                    new() { FlightNumber = "AB123", Departure = "DEL", Arrival = "JFK", ScheduledDate = "2024-11-01 08:30", NumberOfPax = "150" },
                    new() { FlightNumber = "CD456", Departure = "LAX", Arrival = "ORD", ScheduledDate = "2024-11-01 09:30", NumberOfPax = "180" },
                    new() { FlightNumber = "EF789", Departure = "ORD", Arrival = "SFO", ScheduledDate = "2024-11-01 10:30", NumberOfPax = "200" },
                    new() { FlightNumber = "GH012", Departure = "SFO", Arrival = "MIA", ScheduledDate = "2024-11-01 11:30", NumberOfPax = "130" },
                    new() { FlightNumber = "IJ345", Departure = "MIA", Arrival = "LAX", ScheduledDate = "2024-11-01 12:30", NumberOfPax = "220" },
                    new() { FlightNumber = "KL678", Departure = "DFW", Arrival = "SEA", ScheduledDate = "2024-11-01 13:30", NumberOfPax = "170" },
                    new() { FlightNumber = "MN901", Departure = "SEA", Arrival = "ATL", ScheduledDate = "2024-11-01 14:30", NumberOfPax = "160" },
                    new() { FlightNumber = "OP234", Departure = "IAH", Arrival = "PHX", ScheduledDate = "2024-11-01 15:30", NumberOfPax = "180" },
                    new() { FlightNumber = "QR567", Departure = "PHX", Arrival = "DEN", ScheduledDate = "2024-11-01 16:30", NumberOfPax = "190" },
                    new() { FlightNumber = "ST890", Departure = "DEN", Arrival = "DCA", ScheduledDate = "2024-11-01 17:30", NumberOfPax = "150" },
                    new() { FlightNumber = "UV123", Departure = "ATL", Arrival = "BOS", ScheduledDate = "2024-11-01 18:30", NumberOfPax = "220" },
                    new() { FlightNumber = "WX456", Departure = "DCA", Arrival = "BOS", ScheduledDate = "2024-11-01 19:30", NumberOfPax = "210" },
                    new() { FlightNumber = "YZ789", Departure = "BOS", Arrival = "JFK", ScheduledDate = "2024-11-01 20:30", NumberOfPax = "180" },
                    new() { FlightNumber = "IJ246", Departure = "MIA", Arrival = "SEA", ScheduledDate = "2024-11-02 12:30", NumberOfPax = "190" },
                    new() { FlightNumber = "KL357", Departure = "SEA", Arrival = "DFW", ScheduledDate = "2024-11-02 13:30", NumberOfPax = "160" },

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
