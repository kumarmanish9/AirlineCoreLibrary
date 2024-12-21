using AirlineCoreLibrary.Service;
using AirlineCoreLibrary.ServiceDefinition;
using Microsoft.Extensions.DependencyInjection;

namespace AirlineCoreLibrary.Utility
{
    public static class Extension
    {
        public static void RegisterAppServices(this IServiceCollection service)
        {
            service.AddSingleton<IFlightService, FlightService>();
            service.AddSingleton<IPassengerService, PassengerService>();
            service.AddSingleton<IEventPublisher, EventPublisher>();
            service.AddSingleton<IEventProcessor, EventProcessor>();
            service.AddSingleton<IDatabaseService, DatabaseService>();
        }
    }
}
