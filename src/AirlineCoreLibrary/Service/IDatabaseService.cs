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
        /// Saves a new passenger record to the database.
        /// </summary>
        /// <param name="passenger">The passenger object containing the details of the passenger to be saved.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task<Task> SavePassengerAsync(Passenger passenger);

        /// <summary>
        /// Asynchronously retrieves a list of flights from the database.
        /// </summary>
        /// <returns>A task representing the asynchronous operation, with a list of flights as the result.</returns>
        Task<List<Flight>> GetFlightsAsync();

        /// <summary>
        /// Asynchronously retrieves a list of passengers associated with a specific flight from the database.
        /// </summary>
        /// <param name="flightKey">The key identifying the flight for which the passengers need to be fetched.</param>
        /// <returns>A task representing the asynchronous operation, with a list of passengers as the result.</returns>
        Task<List<Passenger>> GetPassengersAsync(string flightKey);


    }

}
