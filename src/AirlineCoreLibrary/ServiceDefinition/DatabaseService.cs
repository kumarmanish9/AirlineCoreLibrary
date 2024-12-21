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
            INSERT IGNORE INTO Flight (FlightKey, FlightNumber, Departure, Arrival, ScheduledDate, NumberOfPax)
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
            INSERT IGNORE INTO Passenger (PassengerKey, FlightKey, Pnr, FirstName, LastName, Phone, Email, Compensation, Status)
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
        public async Task<List<Flight>> GetFlightsAsync()
        {
            // Example database query logic (adjust this based on your actual database context)
            List<Flight> flights = [];

            try
            {
                // Assume you are using ADO.NET or some ORM (e.g., Entity Framework)
                // Sample query: SELECT * FROM Flights;
                using (var connection = GetConnection())
                {
                    await connection.OpenAsync();
                    string query = "SELECT * FROM Flight";
                    var command = new MySqlCommand(query, connection);
                    var reader = await command.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {
                        var flight = new Flight
                        {
                            FlightKey = reader["FlightKey"].ToString(),
                            FlightNumber = reader["FlightNumber"].ToString(),
                            Departure = reader["Departure"].ToString(),
                            Arrival = reader["Arrival"].ToString(),
                            ScheduledDate = reader["ScheduledDate"].ToString(),
                            NumberOfPax = reader["NumberOfPax"].ToString(),
                        };
                        flights.Add(flight);
                    }
                }
            }
            catch (Exception ex)
            {
                // Log or handle the error as appropriate
                AppLogger.LogError("Error occurd while fetching flights",ex);
            }

            return flights;
        }

        /// <inheritdoc />
        /// <inheritdoc />
        public async Task<List<Passenger>> GetPassengersAsync(string flightKey)
        {
            List<Passenger> passengers = [];

            try
            {
                // Example database query logic (adjust this based on your actual database context)
                using (var connection = GetConnection())
                {
                    await connection.OpenAsync();

                    // Query to fetch passengers associated with the given flightKey
                    string query = "SELECT * FROM Passenger WHERE FlightKey = @FlightKey"; // Adjust query as needed
                    var command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@FlightKey", flightKey);
                    var reader = await command.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {
                        var passenger = new Passenger
                        {
                            PassengerKey = reader["PassengerKey"].ToString(),
                            FlightKey = reader["FlightKey"].ToString(),
                            Pnr = reader["Pnr"].ToString(),
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            Phone = reader["Phone"].ToString(),
                            Email = reader["Email"].ToString(),
                            Compensation = reader["Compensation"].ToString(),
                            Status = reader["Status"].ToString(),
                        };
                        passengers.Add(passenger);
                    }
                }
            }
            catch (Exception ex)
            {
                // Log or handle the error as appropriate
                AppLogger.LogError("Error occurd while fetching passengers", ex);
            }

            return passengers;
        }

    }
}
