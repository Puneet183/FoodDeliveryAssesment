using Microsoft.AspNetCore.Mvc;
using RestaurantService.Models;
using Microsoft.EntityFrameworkCore;
namespace RestaurantService.Controllers
{
    [ApiController]
    [Route("api/restaurant")]
    public class RestaurantController : ControllerBase
    {
        private readonly RestaurantDbContext _context;

        public RestaurantController(RestaurantDbContext context)
        {
            _context = context;
        }

        [HttpGet("menus")]
        public IActionResult GetMenu()
        {
            var restaurants = _context.Restaurants.Include(r => r.Menu).ToList();
            return Ok(restaurants);
        }
    }
}