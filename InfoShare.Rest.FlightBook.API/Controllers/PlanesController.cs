using InfoShare.Rest.FlightBook.API.Database;
using InfoShare.Rest.FlightBook.API.DTOs;
using InfoShare.Rest.FlightBook.API.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InfoShare.Rest.FlightBook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanesController : ControllerBase
    {
        private readonly FlightBookContext _context;

        public PlanesController(FlightBookContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlaneDto>> GetPlanes()
        {
            return _context.Planes.Select(x => x.ToDto()).ToList();
        }
    }
}
