using InfoShare.Rest.FlightBook.API.Entities;

namespace InfoShare.Rest.FlightBook.API.Database
{
    public class DbInitializer
    {
        internal static void Initialize(FlightBookContext context)
        {
            context.Planes.AddRange(new[]
            {
                new Plane
                {
                    Registration = "SP-123",
                    RegistrationDate = DateTime.Today.AddMonths(-3),
                    Vendor = "Boeing",
                    AvaibleRows = 120,
                    AvaibleSeats = 6,
                    Model = "737-NG",
                    UpdateDate = DateTime.Now
                } 
            });
            context.SaveChanges();
        }
    }
}
