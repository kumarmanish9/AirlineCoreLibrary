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
                INSERT INTO Flight 
                (FlightKey, FlightNumber, Departure, Arrival, ScheduledDate, EventType, EventReason, IsOvernight, DelayInMinutes, NumberOfPax) 
                VALUES 
                (@FlightKey, @FlightNumber, @Departure, @Arrival, @ScheduledDate, @EventType, @EventReason, @IsOvernight, @DelayInMinutes, @NumberOfPax)
                ON DUPLICATE KEY UPDATE
                FlightNumber = VALUES(FlightNumber),
                Departure = VALUES(Departure),
                Arrival = VALUES(Arrival),
                ScheduledDate = VALUES(ScheduledDate),
                EventType = VALUES(EventType),
                EventReason = VALUES(EventReason),
                IsOvernight = VALUES(IsOvernight),
                DelayInMinutes = VALUES(DelayInMinutes),
                NumberOfPax = VALUES(NumberOfPax)";

            // Open the database connection and execute the command
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
                    cmd.Parameters.AddWithValue("@EventType", flight.EventType);
                    cmd.Parameters.AddWithValue("@EventReason", flight.EventReason);
                    cmd.Parameters.AddWithValue("@IsOvernight", flight.IsOvernight);
                    cmd.Parameters.AddWithValue("@DelayInMinutes", flight.DelayInMinutes);
                    cmd.Parameters.AddWithValue("@NumberOfPax", flight.NumberOfPax);

                    await cmd.ExecuteNonQueryAsync();
                }
            }

            return Task.CompletedTask;
        }

        /// <inheritdoc />
        public async Task<Task> SavePassengerAsync(PassengerCompenation passenger)
        {
            try
            {
                AppLogger.LogInfo("Saving passenger with PassengerKey: ", passenger.PassengerKey);

                var query = @"
                    INSERT INTO Passenger 
                    (PassengerKey, FlightKey, Pnr, FirstName, LastName, Phone, Email, EventReason, CabinType, PaxStatus, IsEligible, Compensation, Status, AgentRemarks, Requester)
                    VALUES 
                    (@PassengerKey, @FlightKey, @Pnr, @FirstName, @LastName, @Phone, @Email, @EventReason, @CabinType, @PaxStatus, @IsEligible, @Compensation, @CompStatus, @AgentRemarks, @Requester)";

                using (var connection = GetConnection())
                {
                    await connection.OpenAsync();

                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@PassengerKey", passenger.PassengerKey);
                        cmd.Parameters.AddWithValue("@FlightKey", passenger.FlightKey);
                        cmd.Parameters.AddWithValue("@Pnr", passenger.PNR);
                        cmd.Parameters.AddWithValue("@FirstName", passenger.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", passenger.LastName);
                        cmd.Parameters.AddWithValue("@Phone", passenger.Phone);
                        cmd.Parameters.AddWithValue("@Email", passenger.Email);
                        cmd.Parameters.AddWithValue("@EventReason", passenger.EventReason);
                        cmd.Parameters.AddWithValue("@CabinType", passenger.CabinType);
                        cmd.Parameters.AddWithValue("@PaxStatus", passenger.PaxStatus);
                        cmd.Parameters.AddWithValue("@IsEligible", passenger.IsEligible);
                        cmd.Parameters.AddWithValue("@Compensation", passenger.Compensation);
                        cmd.Parameters.AddWithValue("@CompStatus", passenger.CompStatus);
                        cmd.Parameters.AddWithValue("@AgentRemarks", passenger.AgentRemarks);
                        cmd.Parameters.AddWithValue("@Requester", passenger.Requester);

                        await cmd.ExecuteNonQueryAsync();
                    }
                }

                AppLogger.LogInfo("Passenger saved successfully", passenger);
            }
            catch (Exception ex)
            {
                AppLogger.LogError("Error saving passenger: ", ex);
            }

            return Task.CompletedTask;
        }

        public async Task<Task> UpdatePassengerAsync(PassengerCompenation passenger)
        {
            try
            {
                AppLogger.LogInfo("Updating passenger with PassengerKey: ", passenger.PassengerKey);

                var query = @"
                    UPDATE Passenger 
                    SET 
                        FlightKey = @FlightKey,
                        Pnr = @Pnr,
                        FirstName = @FirstName,
                        LastName = @LastName,
                        Phone = @Phone,
                        Email = @Email,
                        EventReason = @EventReason,
                        CabinType = @CabinType,
                        PaxStatus = @PaxStatus,
                        IsEligible = @IsEligible,
                        Compensation = @Compensation,
                        Status = @CompStatus,
                        AgentRemarks = @AgentRemarks,
                        Requester = @Requester
                    WHERE PassengerKey = @PassengerKey";

                using (var connection = GetConnection())
                {
                    await connection.OpenAsync();

                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@PassengerKey", passenger.PassengerKey);
                        cmd.Parameters.AddWithValue("@FlightKey", passenger.FlightKey);
                        cmd.Parameters.AddWithValue("@Pnr", passenger.PNR);
                        cmd.Parameters.AddWithValue("@FirstName", passenger.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", passenger.LastName);
                        cmd.Parameters.AddWithValue("@Phone", passenger.Phone);
                        cmd.Parameters.AddWithValue("@Email", passenger.Email);
                        cmd.Parameters.AddWithValue("@EventReason", passenger.EventReason);
                        cmd.Parameters.AddWithValue("@CabinType", passenger.CabinType);
                        cmd.Parameters.AddWithValue("@PaxStatus", passenger.PaxStatus);
                        cmd.Parameters.AddWithValue("@IsEligible", passenger.IsEligible);
                        cmd.Parameters.AddWithValue("@Compensation", passenger.Compensation);
                        cmd.Parameters.AddWithValue("@CompStatus", passenger.CompStatus);
                        cmd.Parameters.AddWithValue("@AgentRemarks", passenger.AgentRemarks);
                        cmd.Parameters.AddWithValue("@Requester", passenger.Requester);

                        await cmd.ExecuteNonQueryAsync();
                    }
                }

                AppLogger.LogInfo("Passenger updated successfully", passenger);
            }
            catch (Exception ex)
            {
                AppLogger.LogError("Error updating passenger: ", ex);
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
                    string query = "SELECT FlightKey, FlightNumber, Departure, Arrival, ScheduledDate, NumberOfPax FROM Flight";
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
        public async Task<List<PassengerCompenation>> GetPassengersAsync(string flightKey)
        {
            List<PassengerCompenation> passengers = [];  // Correct initialization of the list

            try
            {
                using (var connection = GetConnection())
                {
                    await connection.OpenAsync();

                    // Query to fetch passengers associated with the given flightKey
                    string query = @"
                        SELECT PassengerKey, FlightKey, Pnr, FirstName, LastName, Phone, Email, 
                               EventReason, CabinType, PaxStatus, IsEligible, Compensation, Status, 
                               AgentRemarks, Requester
                        FROM Passenger 
                        WHERE FlightKey = @FlightKey"; // Adjust query as needed

                    var command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@FlightKey", flightKey);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var passenger = new PassengerCompenation
                            {
                                PassengerKey = reader["PassengerKey"].ToString(),
                                FlightKey = reader["FlightKey"].ToString(),
                                PNR = reader["Pnr"].ToString(),
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                Phone = reader["Phone"].ToString(),
                                Email = reader["Email"].ToString(),
                                EventReason = reader["EventReason"].ToString(),
                                CabinType = reader["CabinType"].ToString(),
                                PaxStatus = reader["PaxStatus"].ToString(),
                                IsEligible = reader["IsEligible"] != DBNull.Value ? Convert.ToBoolean(reader["IsEligible"]) : (bool?)null,  // Nullable boolean
                                Compensation = reader["Compensation"].ToString(),
                                CompStatus = reader["Status"].ToString(),
                                AgentRemarks = reader["AgentRemarks"].ToString(),
                                Requester = reader["Requester"].ToString()
                            };
                            passengers.Add(passenger);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log or handle the error as appropriate
                AppLogger.LogError("Error occurred while fetching passengers", ex);
            }

            return passengers;
        }


    }
}
