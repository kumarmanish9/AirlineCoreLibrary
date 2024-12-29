namespace AirlineCoreLibrary.Model
{
    /// <summary>
    /// Represents the details of a flight.
    /// </summary>
    public class Flight
    {
        /// <summary>
        /// Gets or sets the unique key for the flight. 
        /// Example: "AA1234_2021-09-01".
        /// </summary>
        public string? FlightKey { get; set; }

        /// <summary>
        /// Gets or sets the flight number. 
        /// Example: "AA1234".
        /// </summary>
        public string? FlightNumber { get; set; }

        /// <summary>
        /// Gets or sets the departure airport code. 
        /// Ensure that Arrival is not equal to Departure.
        /// </summary>
        public string? Departure { get; set; }

        /// <summary>
        /// Gets or sets the arrival airport code. 
        /// Ensure that Arrival is not equal to Departure.
        /// </summary>
        public string? Arrival { get; set; }

        /// <summary>
        /// Gets or sets the scheduled date and time for the flight.
        /// Format: "yyyy-MM-dd hh:mm".
        /// </summary>
        public string? ScheduledDate { get; set; }

        /// <summary>
        /// Gets or sets the type of the event affecting the flight.
        /// Possible values: "Controllable", "Uncontrollable".
        /// </summary>
        public string? EventType { get; set; }

        /// <summary>
        /// Gets or sets the reason for the event affecting the flight.
        /// Possible values: "Cancel", "Delay", "Unknown".
        /// </summary>
        public string? EventReason { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the flight is overnight.
        /// </summary>
        public bool? IsOvernight { get; set; }

        /// <summary>
        /// Gets or sets the delay in minutes.
        /// Range: 100 to 480.
        /// </summary>
        public int? DelayInMinutes { get; set; }

        /// <summary>
        /// Gets or sets the number of passengers on the flight.
        /// Range: 1 to 50.
        /// </summary>
        public string? NumberOfPax { get; set; }
    }
}