using AirlineCoreLibrary.Model;
using Org.BouncyCastle.Asn1.Cmp;

namespace AirlineCoreLibrary.Utility
{
    internal static class FlightEventGenerator
    {
        private static readonly Random _random = new ();

        public static FlightEvent CreateFlightEvent()
        {
            // Generate a random flight
            var flightNumber = DataProvider.FlightNumbers[_random.Next(DataProvider.FlightNumbers.Length)];
            var departure = DataProvider.Departures[_random.Next(DataProvider.Departures.Length)];
            var arrival = DataProvider.Arrivals.Except(new[] { departure }).ElementAt(_random.Next(DataProvider.Arrivals.Length - 1));// Ensure arrival != departure
            var scheduledDate = DateTime.Now.AddDays(_random.Next(1, 2)).ToString("yyyy-MM-dd"); // Random future date
            var numberOfPax = _random.Next(1, 50).ToString(); // Random number of passengers (1-5)
            var delayInMinutes = _random.Next(100, 480);
            var eventReason = DataProvider.EventReason[_random.Next(DataProvider.EventReason.Length)];
            var eventType = DataProvider.EventType[_random.Next(DataProvider.EventType.Length)];

            var flight = new Flight
            {
                FlightNumber = flightNumber,
                Departure = departure,
                Arrival = arrival,
                ScheduledDate = scheduledDate,
                NumberOfPax = numberOfPax,
                DelayInMinutes = delayInMinutes,
                EventReason = eventReason,
                EventType = eventType,
                IsOvernight = _random.Next(0, 1) == 1,
            };

            // Generate random passengers
            int passengerCount = int.Parse(numberOfPax);
            var pnr = GenerateRandomPnr();
            var passengers = Enumerable.Range(0, passengerCount).Select(i =>
            {
                var firstName = DataProvider.FirstNames[_random.Next(DataProvider.FirstNames.Length)];
                var lastName = DataProvider.LastNames[_random.Next(DataProvider.LastNames.Length)];
                var email = DataProvider.Emails[_random.Next(DataProvider.Emails.Length)];
                var cabinType = DataProvider.CabinType[_random.Next(DataProvider.CabinType.Length)];
                var paxStatus = DataProvider.PaxStatus[_random.Next(DataProvider.PaxStatus.Length)];
                var phone = GenerateRandomPhoneNumber();

                return new PassengerCompenation
                {
                    FlightKey = null,
                    FirstName = firstName,
                    LastName = lastName,
                    Phone = phone,
                    Email = email,
                    PNR = pnr,
                    CabinType = cabinType,
                    PaxStatus = paxStatus,
                    Requester = "Auto",
                    AgentRemarks = "NA",
                    CompStatus = null,
                    Compensation = null,
                    IsEligible = null,
                    PassengerKey = null
                };
            }).ToArray();

            return new FlightEvent
            {
                Flight = flight,
                Passengers = passengers
            };
        }

        private static string GenerateRandomPhoneNumber()
        {
            return "9" + string.Join("", Enumerable.Range(0, 9).Select(_ => _random.Next(0, 10)));
        }

        private static string GenerateRandomPnr()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Range(0, 6).Select(_ => chars[_random.Next(chars.Length)]).ToArray());
        }
    }
}
