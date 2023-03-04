using InfoShare.Rest.FlightBook.API.DTOs;
using InfoShare.Rest.FlightBook.API.Entities;

namespace InfoShare.Rest.FlightBook.API.Mappers
{
    public static class PlaneMapper
    {
        public static PlaneDto ToDto(this Plane plane)
        {
            return new PlaneDto
            {
                AvaibleRows = plane.AvaibleRows,
                AvaibleSeats= plane.AvaibleSeats,
                Model= plane.Model,
                Registration= plane.Registration,
                RegistrationDate= plane.RegistrationDate,
                UpdateDate= plane.UpdateDate,
                Vendor = plane.Vendor
            };
        }
    }
}
