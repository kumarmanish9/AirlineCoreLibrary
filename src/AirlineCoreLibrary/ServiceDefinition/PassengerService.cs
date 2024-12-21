using AirlineCoreLibrary.Model;
using AirlineCoreLibrary.Service;

namespace AirlineCoreLibrary.ServiceDefinition
{
    public class PassengerService : IPassengerService
    {
        public async Task<List<Passenger>?> GetPassenger(Flight? flight)
        {
            try
            {
                var passengers = new List<Passenger>()
                {
                    new Passenger() { Pnr = "PNR001", FirstName = "John", LastName = "Doe", Phone = "1234567890", Email = "john.doe@example.com", HotelStatus = "Booked", MealStatus = "Vegetarian", OfferStatus = "Accepted" },
                    new Passenger() { Pnr = "PNR002", FirstName = "Jane", LastName = "Smith", Phone = "2345678901", Email = "jane.smith@example.com", HotelStatus = "Not Booked", MealStatus = "Non-Vegetarian", OfferStatus = "Rejected" },
                    new Passenger() { Pnr = "PNR003", FirstName = "Robert",LastName = "Brown", Phone = "", Email = "robert.brown@example.com", HotelStatus = "Booked", MealStatus = "Vegan", OfferStatus = "Accepted" },
                    new Passenger() { Pnr = "PNR004", FirstName = "Emily", LastName = "White", Phone = "4567890123", Email = "avl", HotelStatus = "Not Booked", MealStatus = "Vegetarian", OfferStatus = "Accepted" },
                    new Passenger() { Pnr = "PNR006", FirstName = "Sarah", LastName = "Taylor", Phone = "", Email = "sarah.taylor@example.com", HotelStatus = "Not Booked", MealStatus = "Vegan", OfferStatus = "Rejected" },
                    new Passenger() { Pnr = "PNR007", FirstName = "David", LastName = "Harris", Phone = "7890123456", Email = "david.harris@example.com", HotelStatus = "Booked", MealStatus = "Non-Vegetarian", OfferStatus = "Accepted" },
                    new Passenger() { Pnr = "PNR008", FirstName = "Linda", LastName = "Martin", Phone = "", Email = "linda.martin@example.com", HotelStatus = "Not Booked", MealStatus = "Vegetarian", OfferStatus = "Pending" },
                    new Passenger() { Pnr = "PNR009", FirstName = "James", LastName = "Lee", Phone = "9012345678", Email = "", HotelStatus = "Booked", MealStatus = "Non-Vegetarian", OfferStatus = "Accepted" },
                    new Passenger() { Pnr = "PNR010", FirstName = "Karen", LastName = "Perez", Phone = "0123456789", Email = "karen.perez@example.com", HotelStatus = "Not Booked", MealStatus = "Vegan", OfferStatus = "Rejected" }
                };

                return passengers;
            }
            catch
            {
                await Task.Delay(1000);
                return null;
            }
        }

        public async Task<List<Passenger>?> GetPassengerV2(Flight? flight)
        {
            try
            {
                // Create a random number generator
                Random random = new Random();

                // Define random count between 5 and 20
                int passengerCount = random.Next(5, 21);

                // Predefined data for generating random passengers
                var firstNames = new[] { "John", "Jane", "Robert", "Karen", "Emily", "Michael", "Sarah", "David", "Jessica", "Daniel" };
                var lastNames = new[] { "Doe", "Smith", "Brown", "Perez", "Johnson", "Lee", "Martinez", "Garcia", "Hernandez", "Taylor" };
                var hotelStatuses = new[] { "Booked", "Not Booked" };
                var mealStatuses = new[] { "Vegetarian", "Non-Vegetarian", "Vegan" };
                var offerStatuses = new[] { "Accepted", "Rejected" };

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
                        HotelStatus = hotelStatuses[random.Next(hotelStatuses.Length)],
                        MealStatus = mealStatuses[random.Next(mealStatuses.Length)],
                        OfferStatus = offerStatuses[random.Next(offerStatuses.Length)],
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
