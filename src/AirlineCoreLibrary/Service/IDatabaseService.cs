using AirlineCoreLibrary.Model;

namespace AirlineCoreLibrary.Service
{
    /// <summary>
    /// Provides methods for managing database operations related to flights and passengers.
    /// </summary>
    public interface IDatabaseService
    {
        /// <summary>
        /// CheckConnection
        /// </summary>
        /// <returns></returns>
        bool CheckConnection();

        /// <summary>
        /// Saves a new flight record to the database.
        /// </summary>
        /// <param name="flight">The flight object containing the details of the flight to be saved.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task<Task> SaveFlightAsync(Flight flight);

        /// <summary>
        /// Updates an existing flight record in the database.
        /// </summary>
        /// <param name="flight">The flight object containing the updated details of the flight.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task<Task> UpdateFlightAsync(Flight flight);

        /// <summary>
        /// Saves a new passenger record to the database.
        /// </summary>
        /// <param name="passenger">The passenger object containing the details of the passenger to be saved.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task<Task> SavePassengerAsync(Passenger passenger);

        /// <summary>
        /// Updates an existing passenger record in the database.
        /// </summary>
        /// <param name="passenger">The passenger object containing the updated details of the passenger.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task<Task> UpdatePassengerAsync(Passenger passenger);
    }

}
