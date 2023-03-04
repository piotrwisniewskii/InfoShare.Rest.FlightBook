using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InfoShare.Rest.FlightBook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NumbersController : ControllerBase
    {
        [HttpGet("random")]
        public int GetNumber()
        {
            return 1;
        }

        [HttpGet("multiplication/{a}/{b}")]  // Mapowanie URL do parametrów metody
        public int Multiply(int a, int b)
        {
            return a * b;
        }
    }
}
