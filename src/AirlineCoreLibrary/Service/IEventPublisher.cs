using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineCoreLibrary.Service
{
    /// <summary>
    /// Defines a contract for publishing flight-related events.
    /// </summary>
    public interface IEventPublisher
    {
        /// <summary>
        /// Publishes a flight event asynchronously.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// </returns>
        Task PublishFlightEventAsync();
    }

}
