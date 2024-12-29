namespace AirlineCoreLibrary.Model
{
    /// <summary>
    /// Represents the details of a passenger's compensation.
    /// </summary>
    public class PassengerCompenation
    {
        /// <summary>
        /// Gets or sets the unique identifier for the passenger.
        /// </summary>
        public string? PassengerKey { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the flight.
        /// </summary>
        public string? FlightKey { get; set; }

        /// <summary>
        /// Gets or sets the Passenger Name Record (PNR).
        /// </summary>
        public string? PNR { get; set; }

        /// <summary>
        /// Gets or sets the passenger's first name.
        /// </summary>
        public string? FirstName { get; set; }

        /// <summary>
        /// Gets or sets the passenger's last name.
        /// </summary>
        public string? LastName { get; set; }

        /// <summary>
        /// Gets or sets the passenger's phone number.
        /// </summary>
        public string? Phone { get; set; }

        /// <summary>
        /// Gets or sets the passenger's email address.
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Gets or sets the EventReason (e.g. Cancel, Delay and Unknown ).
        /// </summary>
        public string? EventReason { get; set; }

        /// <summary>
        /// Gets or sets the cabin type (e.g., Economy, Premium, Business).
        /// </summary>
        public string? CabinType { get; set; }

        /// <summary>
        /// Gets or sets the passenger status (e.g., Gold, Silver, Platinum, General).
        /// </summary>
        public string? PaxStatus { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the passenger is eligible for compensation.
        /// </summary>
        /// </summary>
        public bool? IsEligible { get; set; }

        /// <summary>
        /// Gets or sets the type of compensation (e.g., Hotel, Meal, HotelAndMeal, Voucher, Miles).
        /// </summary>
        public string? Compensation { get; set; }

        /// <summary>
        /// Gets or sets the compensation status (e.g., Offered, NotEligible, Pending, Accepted, Declined, Voided).
        /// </summary>
        public string? CompStatus { get; set; }

        /// <summary>
        /// Gets or sets remarks from the agent handling the compensation request.
        /// </summary>
        public string? AgentRemarks { get; set; }

        /// <summary>
        /// Gets or sets who requested the compensation (e.g., Auto, Agent).
        /// </summary>
        public string? Requester { get; set; }
    }

}
