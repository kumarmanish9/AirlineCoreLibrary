using AirlineCoreLibrary.Model;
using AirlineCoreLibrary.Service;
using AirlineCoreLibrary.Utility;
using Newtonsoft.Json;

namespace AirlineCoreLibrary.ServiceDefinition
{
    public class EventPublisher : IEventPublisher
    {
        public async Task PublishFlightEventAsync()
        {
            try
            {
                // Generate the flight event
                FlightEvent flightEvent = FlightEventGenerator.CreateFlightEvent();

                // Serialize the event to a JSON string
                string message = JsonConvert.SerializeObject(flightEvent, Formatting.Indented);

                // Dynamically generate the file name with a timestamp
                string fileName = $"FlightEvent_{DateTime.Now:yyyyMMdd_HHmmss}.json";
                string filePath = System.IO.Path.Combine(CoreConstants.EventMessagePath, fileName);

                // Write the JSON message to the file
                await System.IO.File.WriteAllTextAsync(filePath, message);

                Console.WriteLine($"Flight event successfully published to {filePath}");
            }
            catch (Exception ex)
            {
                throw new System.Exception("Failed to publish event", ex);
            }
        }
    }
}
