using AirlineCoreLibrary.Service;
using AirlineCoreLibrary.ServiceDefinition;
using Microsoft.Extensions.DependencyInjection;

namespace AirlineCoreLibrary.Utility
{
    public static class Extension
    {
        /// <summary>
        /// Registers application services into the service collection.
        /// </summary>
        /// <param name="service">The service collection to register services with.</param>
        public static void RegisterAppServices(this IServiceCollection service)
        {
            // Register HttpClient
            service.AddHttpClient();

            // Register application services with the service container
            service.AddSingleton<IFlightService, FlightService>();
            service.AddSingleton<IPassengerService, PassengerService>();
            service.AddSingleton<IEventPublisher, EventPublisher>();
            service.AddSingleton<IEventProcessor, EventProcessor>();
            service.AddSingleton<ICompensationProcessor, CompensationProcessor>();
            service.AddSingleton<INotification, Notification>();
            service.AddSingleton<IDatabaseService, DatabaseService>();
            service.AddSingleton<IRuleEngineService, RuleEngineService>();

            // Add other services as needed
        }
    }
}
