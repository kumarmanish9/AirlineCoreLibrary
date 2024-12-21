using AirlineCoreLibrary.Model;
using AirlineCoreLibrary.Service;
using AirlineCoreLibrary.Utility;
using Newtonsoft.Json;

namespace AirlineCoreLibrary.ServiceDefinition
{
    internal class EventProcessor(IDatabaseService database) : IEventProcessor
    {
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
                        // Process each file
                        foreach (var filePath in filePaths)
                        {
                            string fileName = Path.GetFileName(filePath);
                            try
                            {
                                // Read the content of the file asynchronously
                                string jsonContent = await File.ReadAllTextAsync(filePath);

                                // Deserialize the JSON content into a FlightEvent object
                                FlightEvent? flightEvent = JsonConvert.DeserializeObject<FlightEvent>(jsonContent);

                                if (flightEvent?.Flight != null && flightEvent?.Passengers != null)
                                {
                                    // Process the FlightEvent object (print details in this example)
                                    AppLogger.LogInfo($"Processing Flight Event, EventId: {fileName}");

                                    // Example: Save/Update flight details
                                    flightEvent.Flight.PK = flightEvent.Flight.GenerateFlightKey();
                                    await database.SaveFlightAsync(flightEvent.Flight);

                                    // Example: Save/Update passenger details
                                    foreach (var passenger in flightEvent.Passengers)
                                    {
                                        passenger.PK = passenger.GeneratePassengerKey();
                                        passenger.FlightKey = flightEvent.Flight.PK;
                                        await database.SavePassengerAsync(passenger);
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
                                AppLogger.LogError($"An error occurred while processing the message", ex);
                            }

                            // Delete the file after processing
                            File.Delete(filePath);
                            AppLogger.LogInfo($"Events removed from queue, EventId: {fileName}");
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

    }
}
