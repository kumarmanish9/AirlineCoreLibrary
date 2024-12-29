using AirlineCoreLibrary.Model;
using AirlineCoreLibrary.Service;
using AirlineCoreLibrary.Utility;
using Newtonsoft.Json;

namespace AirlineCoreLibrary.ServiceDefinition
{
    /// <summary>
    /// Processes flight-related events and interacts with the database service.
    /// </summary>
    internal class EventProcessor(IDatabaseService database, ICompensationProcessor compensation) : IEventProcessor
    {
        /// <inheritdoc />
        public async Task ProcessFlightEventAsync()
        {
            try
            {
                // Define the directory containing the JSON files
                string directoryPath = CoreConstants.EventMessagePath;

                // Ensure the directory exists
                if (Directory.Exists(directoryPath))
                {
                    // Get all JSON files in the directory
                    string[] filePaths = Directory.GetFiles(directoryPath, "*.json");
                    if (filePaths.Length > 0)
                    {
                        if (CoreConstants.IsParrallExecution)
                        {
                            // Process each file in parallel
                            await Parallel.ForEachAsync(filePaths, async (filePath, cancellationToken) =>
                            {
                                await ProcessEventMessage(filePath);
                            });
                        }
                        else
                        {
                            // Process each file in sequence
                            foreach (string filePath in filePaths)
                            {
                                await ProcessEventMessage(filePath);
                            }
                        }
                    }
                    else
                    {
                        AppLogger.LogInfo("No flight events found to process");
                    }
                }
                else
                {
                    AppLogger.LogInfo($"Queue does not have message");
                }
            }
            catch (Exception ex)
            {
                AppLogger.LogError($"An error occurred while processing the flight events", ex);
            }
        }

        /// <summary>
        /// ProcessEventMessage
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        private async Task ProcessEventMessage(string filePath)
        {
            // Get the file name from the path
            string fileName = Path.GetFileName(filePath);

            try
            {
                // Read the content of the file asynchronously
                string jsonContent = await File.ReadAllTextAsync(filePath);

                // Deserialize the JSON content into a FlightEvent object
                FlightEvent? flightEvent = JsonConvert.DeserializeObject<FlightEvent>(jsonContent);

                if (flightEvent?.Flight != null && flightEvent?.Passengers != null)
                {
                    // Process the FlightEvent object (log details in this example)
                    AppLogger.LogInfo($"Processing Flight Event, EventId: {fileName}");

                    // Save/Update flight details
                    flightEvent.Flight.FlightKey = flightEvent.Flight.GenerateFlightKey();
                    await database.SaveFlightAsync(flightEvent.Flight);

                    // Save/Update passenger details in parallel
                    if (CoreConstants.IsParrallExecution)
                    {
                        var savePassengerTasks = flightEvent.Passengers.Select(async passenger =>
                        {
                            passenger.PassengerKey = passenger.GeneratePassengerKey();
                            passenger.FlightKey = flightEvent.Flight.FlightKey;
                            passenger.EventReason = flightEvent.Flight.EventReason;
                            await database.SavePassengerAsync(passenger);

                            // Compensation Eligibility and Processing
                            await compensation.ProcessCompensationAsync(flightEvent.Flight, passenger);
                        });

                        // Wait for all passenger save tasks to complete
                        await Task.WhenAll(savePassengerTasks);
                    }
                    else
                    {
                        foreach (var passenger in flightEvent.Passengers)
                        {
                            passenger.PassengerKey = passenger.GeneratePassengerKey();
                            passenger.FlightKey = flightEvent.Flight.FlightKey;
                            passenger.EventReason = flightEvent.Flight.EventReason;
                            await database.SavePassengerAsync(passenger);

                            // Compensation Eligibility and Processing
                            await compensation.ProcessCompensationAsync(flightEvent.Flight, passenger);
                        }
                    }
                }
                else
                {
                    AppLogger.LogWarning($"Failed to deserialize the EventId: {fileName}");
                }
            }
            catch (Exception ex)
            {
                // Log or handle the error for this specific file
                AppLogger.LogError($"An error occurred while processing the message for EventId: {fileName}", ex);
            }

            try
            {
                // Delete the file after processing
                File.Delete(filePath);
                AppLogger.LogInfo($"Events removed from queue, EventId: {fileName}");
            }
            catch (Exception ex)
            {
                AppLogger.LogError($"Failed to delete the file: {fileName}", ex);
            }
        }
    }
}
