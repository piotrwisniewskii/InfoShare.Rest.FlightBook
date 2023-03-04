namespace InfoShare.Rest.FlightBook.API.Entities
{
    public class Plane
    {
        public string Registration { get; set; }
        public string Vendor { get; set; }
        public string Model { get; set; }
        public int AvaibleRows { get; set; }
        public int AvaibleSeats { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
