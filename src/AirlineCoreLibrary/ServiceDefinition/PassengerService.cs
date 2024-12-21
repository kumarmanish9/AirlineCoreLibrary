using AirlineCoreLibrary.Model;
using AirlineCoreLibrary.Service;

namespace AirlineCoreLibrary.ServiceDefinition
{
    /// <summary>
    /// Provides services for retrieving passenger information.
    /// </summary>
    public class PassengerService : IPassengerService
    {
        /// <inheritdoc />
        public async Task<List<Passenger>?> GetPassenger(Flight? flight)
        {
            try
            {
                var passengers = new List<Passenger>()
                {
                    new Passenger() { Pnr = "PNR001", FirstName = "John", LastName = "Doe", Phone = "1234567890", Email = "john.doe@example.com", Compensation = "Hotel", Status = "Accepted" },
                    new Passenger() { Pnr = "PNR002", FirstName = "Jane", LastName = "Smith", Phone = "2345678901", Email = "jane.smith@example.com", Compensation = "Meal", Status = "Rejected" },
                    new Passenger() { Pnr = "PNR003", FirstName = "Robert",LastName = "Brown", Phone = "", Email = "robert.brown@example.com", Compensation = "Meal", Status = "Accepted" },
                    new Passenger() { Pnr = "PNR004", FirstName = "Emily", LastName = "White", Phone = "4567890123", Email = "avl", Compensation = "Meal", Status = "Accepted" },
                    new Passenger() { Pnr = "PNR006", FirstName = "Sarah", LastName = "Taylor", Phone = "", Email = "sarah.taylor@example.com", Compensation = "Hotel+Meal",  Status = "Rejected" },
                    new Passenger() { Pnr = "PNR007", FirstName = "David", LastName = "Harris", Phone = "7890123456", Email = "david.harris@example.com", Compensation = "Hotel+Meal", Status = "Accepted" },
                    new Passenger() { Pnr = "PNR008", FirstName = "Linda", LastName = "Martin", Phone = "", Email = "linda.martin@example.com", Compensation = "Hotel+Meal", Status = "Pending" },
                    new Passenger() { Pnr = "PNR009", FirstName = "James", LastName = "Lee", Phone = "9012345678", Email = "", Compensation = "Booked", Status = "Mal" },
                    new Passenger() { Pnr = "PNR010", FirstName = "Karen", LastName = "Perez", Phone = "0123456789", Email = "karen.perez@example.com", Compensation = "Meal", Status = "Rejected" }
                };

                return passengers;
            }
            catch
            {
                await Task.Delay(1000);
                return null;
            }
        }

        /// <inheritdoc />
        public async Task<List<Passenger>?> GetPassengerV2(Flight? flight)
        {
            try
            {
                // Create a random number generator
                Random random = new ();

                // Define random count between 5 and 20
                int passengerCount = random.Next(5, 21);

                // Predefined data for generating random passengers
                var firstNames = new[] { "John", "Jane", "Robert", "Karen", "Emily", "Michael", "Sarah", "David", "Jessica", "Daniel" };
                var lastNames = new[] { "Doe", "Smith", "Brown", "Perez", "Johnson", "Lee", "Martinez", "Garcia", "Hernandez", "Taylor" };
                var Compensationes = new[] { "Hotel", "Meal", "Hotel+Meal", "Voucher", "Miles" };
                var Statuses = new[] { "Accepted", "Rejected" };

                // Generate the list of passengers
                var passengers = new List<Passenger>();
                for (int i = 0; i < passengerCount; i++)
                {
                    var passenger = new Passenger
                    {
                        Pnr = $"PNR{random.Next(1, 1000).ToString("D3")}", // Random 3-digit PNR
                        FirstName = firstNames[random.Next(firstNames.Length)],
                        LastName = lastNames[random.Next(lastNames.Length)],
                        Phone = random.Next(100000000, 999999999).ToString(), // Generate a 10-digit phone number
                        Email = $"{Guid.NewGuid().ToString().Substring(0, 5)}@example.com", // Randomized email
                        Compensation = Compensationes[random.Next(Compensationes.Length)],
                        Status = Statuses[random.Next(Statuses.Length)],
                    };
                    passengers.Add(passenger);
                }

                return await Task.FromResult(passengers); // Return the generated list asynchronously
            }
            catch
            {
                await Task.Delay(1000);
                return null;
            }
        }

    }
}
