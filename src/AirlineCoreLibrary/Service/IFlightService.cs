using AirlineCoreLibrary.Model;

namespace AirlineCoreLibrary.Service
{
    /// <summary>
    /// Defines a contract for retrieving flight-related data.
    /// </summary>
    public interface IFlightService
    {
        /// <summary>
        /// Retrieves a list of flights asynchronously.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation, containing a list of <see cref="Flight"/> objects,
        /// or <c>null</c> if no flights are available.
        /// </returns>
        Task<List<Flight>?> GetFlights();
    }

}
