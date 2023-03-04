using InfoShare.Rest.FlightBook.API.Database;
using InfoShare.Rest.FlightBook.API.DTOs;
using InfoShare.Rest.FlightBook.API.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

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
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<PlaneDto>>> GetPlanes()
        {
            return await _context.Planes.Select(x => x.ToDto()).ToListAsync();
        }


        [HttpGet("{registration}")]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<PlaneDto>> GetSinglePlane(string registration)
        {
            var singlePlane = await _context.Planes.FirstOrDefaultAsync(x => x.Registration == registration);

            if (singlePlane == null)
            {
                return NotFound();
            }
            return singlePlane.ToDto();


        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreatePlane(PlaneDto dto)
        {

            var entity = dto.ToEntity();
            await _context.Planes.AddAsync(entity);

            try
            {
            await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                if (await PlaneExists(dto.Registration))
                {
                    return Conflict();
                }
            }

            return CreatedAtAction(nameof(GetPlanes), new { registration = dto.Registration }, entity.ToDto());
        }

        private Task<bool> PlaneExists(string registration)
        {
            return _context.Planes.AnyAsync(x => x.Registration == registration);
        }
    }
}
