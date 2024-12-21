using AirlineCoreLibrary.Model;

namespace AirlineCoreLibrary.Utility
{
    public static class Helper
    {
        /// <summary>
        /// Generates a new GUID and returns it as a string without hyphens.
        /// </summary>
        /// <returns>A string representing a new GUID without hyphens.</returns>
        public static string GetNewGuid()
        {
            return Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// Generates a flight key based on the flight number, departure airport, and scheduled date.
        /// </summary>
        /// <param name="flight">The flight for which the key will be generated.</param>
        /// <returns>A string representing the flight key.</returns>
        public static string GenerateFlightKey(this Flight flight)
        {
            // Ensure ScheduledDate is not null and parse it into a DateTime object
            if (DateTime.TryParse(flight.ScheduledDate, out DateTime scheduledDate))
            {
                // Format the date into MMDDYYYY
                string formattedDate = scheduledDate.ToString("MMddyyyy");

                // Generate the flight key using the formatted date
                return $"{flight.FlightNumber}_{flight.Departure}_{formattedDate}";
            }

            // If the scheduled date is invalid, fallback to current date and time
            return $"{flight.FlightNumber}_{flight.Departure}_{DateTime.Now.ToString("MMddyyyy")}";
        }

        /// <summary>
        /// Generates a passenger key based on the PNR, first name, and last name.
        /// </summary>
        /// <param name="passenger">The passenger for which the key will be generated.</param>
        /// <returns>A string representing the passenger key.</returns>
        public static string GeneratePassengerKey(this Passenger passenger)
        {
            return $"{passenger.Pnr}_{passenger.FirstName}_{passenger.LastName}";
        }



    }
}
