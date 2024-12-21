using AirlineCoreLibrary.Model;

namespace AirlineCoreLibrary.Service
{
    /// <summary>
    /// Defines a contract for retrieving passenger-related data.
    /// </summary>
    public interface IPassengerService
    {
        /// <summary>
        /// Retrieves a list of passengers associated with a specific flight asynchronously.
        /// </summary>
        /// <param name="flight">The flight object for which the passengers are to be retrieved. Can be <c>null</c>.</param>
        /// <returns>
        /// A task that represents the asynchronous operation, containing a list of <see cref="Passenger"/> objects,
        /// or <c>null</c> if no passengers are available or the flight is <c>null</c>.
        /// </returns>
        Task<List<Passenger>?> GetPassenger(Flight? flight);

        /// <summary>
        /// Retrieves a list of passengers associated with a specific flight asynchronously using an alternative implementation.
        /// </summary>
        /// <param name="flight">The flight object for which the passengers are to be retrieved. Can be <c>null</c>.</param>
        /// <returns>
        /// A task that represents the asynchronous operation, containing a list of <see cref="Passenger"/> objects,
        /// or <c>null</c> if no passengers are available or the flight is <c>null</c>.
        /// </returns>
        Task<List<Passenger>?> GetPassengerV2(Flight? flight);
    }

}
