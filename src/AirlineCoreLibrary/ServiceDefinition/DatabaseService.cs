using AirlineCoreLibrary.Model;
using AirlineCoreLibrary.Service;
using AirlineCoreLibrary.Utility;
using MySql.Data.MySqlClient;

namespace AirlineCoreLibrary.ServiceDefinition
{
    /// <summary>
    /// Provides database-related operations for managing flights and passengers.
    /// </summary>
    internal class DatabaseService : IDatabaseService
    {
        private static MySqlConnection GetConnection()
        {
            return new MySqlConnection(CoreConstants.ConnectionString);
        }

        public bool CheckConnection()
        {
            bool isConnected = false;
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    isConnected = connection.State == System.Data.ConnectionState.Open;
                    connection.Close();
                    AppLogger.LogInfo("Connection successful!");
                }
            }
            catch (Exception ex)
            {
                AppLogger.LogError($"Connection failed", ex);
            }
            return isConnected;
        }

        /// <inheritdoc />
        public async Task<Task> SaveFlightAsync(Flight flight)
        {
            bool isConnected = CheckConnection();
            if (!isConnected)
            {
                return Task.FromException(new Exception("Database connection failed"));
            }
            AppLogger.LogInfo("Saving flight", flight);

            var query = @"
            INSERT INTO Flight (FlightKey, FlightNumber, Departure, Arrival, ScheduledDate, NumberOfPax)
            VALUES (@FlightKey, @FlightNumber, @Departure, @Arrival, @ScheduledDate, @NumberOfPax)";

            using (var connection = GetConnection())
            {
                await connection.OpenAsync();
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@FlightKey", flight.FlightKey);
                    cmd.Parameters.AddWithValue("@FlightNumber", flight.FlightNumber);
                    cmd.Parameters.AddWithValue("@Departure", flight.Departure);
                    cmd.Parameters.AddWithValue("@Arrival", flight.Arrival);
                    cmd.Parameters.AddWithValue("@ScheduledDate", flight.ScheduledDate);
                    cmd.Parameters.AddWithValue("@NumberOfPax", flight.NumberOfPax);

                    await cmd.ExecuteNonQueryAsync();
                }
            }

            return Task.CompletedTask;
        }

        /// <inheritdoc />
        public async Task<Task> SavePassengerAsync(Passenger passenger)
        {
            AppLogger.LogInfo("Saving passenger", passenger);
            var query = @"
            INSERT INTO Passenger (PassengerKey, FlightKey, Pnr, FirstName, LastName, Phone, Email, Compensation, Status)
            VALUES (@PassengerKey, @FlightKey, @Pnr, @FirstName, @LastName, @Phone, @Email, @Compensation, @Status)";

            using (var connection = GetConnection())
            {
                await connection.OpenAsync();
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@PassengerKey", passenger.PassengerKey);
                    cmd.Parameters.AddWithValue("@FlightKey", passenger.FlightKey);
                    cmd.Parameters.AddWithValue("@Pnr", passenger.Pnr);
                    cmd.Parameters.AddWithValue("@FirstName", passenger.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", passenger.LastName);
                    cmd.Parameters.AddWithValue("@Phone", passenger.Phone);
                    cmd.Parameters.AddWithValue("@Email", passenger.Email);
                    cmd.Parameters.AddWithValue("@Compensation", passenger.Compensation);
                    cmd.Parameters.AddWithValue("@Status", passenger.Status);

                    await cmd.ExecuteNonQueryAsync();
                }
            }

            return Task.CompletedTask;
        }

        /// <inheritdoc />
        public Task<Task> UpdateFlightAsync(Flight flight)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<Task> UpdatePassengerAsync(Passenger passenger)
        {
            throw new NotImplementedException();
        }
    }
}
