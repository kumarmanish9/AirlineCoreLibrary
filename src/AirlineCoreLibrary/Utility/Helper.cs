using AirlineCoreLibrary.Model;

namespace AirlineCoreLibrary.Utility
{
    public static class Helper
    {
        public static string GetNewGuid()
        {
            return Guid.NewGuid().ToString("N");
        }

        public static string GenerateFlightKey(this Flight flight)
        {
            // Parse the ScheduledDate into a DateTime object
            DateTime scheduledDate = DateTime.Parse(flight.ScheduledDate ?? DateTime.Now.ToString());

            // Format the date into MMDDYYYYHHMM
            string formattedDate = scheduledDate.ToString("MMddyyyy");

            // Generate the flight key using the formatted date
            return $"{flight.FlightNumber}_{flight.Departure}_{formattedDate}";
        }

        public static string GeneratePassengerKey(this Passenger passenger)
        {
            return $"{passenger.Pnr}_{passenger.FirstName}_{passenger.LastName}";
        }
    }
}
