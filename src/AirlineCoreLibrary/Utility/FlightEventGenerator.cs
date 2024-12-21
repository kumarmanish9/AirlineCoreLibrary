using AirlineCoreLibrary.Model;

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
            var numberOfPax = _random.Next(1, 5).ToString(); // Random number of passengers (1-5)

            var flight = new Flight
            {
                FlightNumber = flightNumber,
                Departure = departure,
                Arrival = arrival,
                ScheduledDate = scheduledDate,
                NumberOfPax = numberOfPax
            };

            // Generate random passengers
            int passengerCount = int.Parse(numberOfPax);
            var pnr = GenerateRandomPnr();
            var passengers = Enumerable.Range(0, passengerCount).Select(i =>
            {
                var firstName = DataProvider.FirstNames[_random.Next(DataProvider.FirstNames.Length)];
                var lastName = DataProvider.LastNames[_random.Next(DataProvider.LastNames.Length)];
                var email = DataProvider.Emails[_random.Next(DataProvider.Emails.Length)];
                var phone = GenerateRandomPhoneNumber();

                return new Passenger
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Phone = phone,
                    Email = email,
                    Pnr = pnr
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
