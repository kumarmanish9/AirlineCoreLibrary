namespace AirlineCoreLibrary.Service
{
    /// <summary>
    /// Defines a contract for processing flight-related events.
    /// </summary>
    public interface IEventProcessor
    {
        /// <summary>
        /// Processes a flight event asynchronously.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// </returns>
        Task ProcessFlightEventAsync();
    }

}
