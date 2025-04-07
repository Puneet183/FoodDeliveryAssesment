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
    
      private static readonly List<Restaurant> Restaurants = new()
    {
        new Restaurant
        {
            Id = 1,
            Name = "Pizza Place",
            Menu = new List<MenuItem>
            {
                new MenuItem { Id = 1, Name = "Pepperoni Pizza", Price = 12 },
                new MenuItem { Id = 2, Name = "Margherita Pizza", Price = 10 }
            }
        },
        new Restaurant
        {
            Id = 2,
            Name = "Burger Joint",
            Menu = new List<MenuItem>
            {
                new MenuItem { Id = 3, Name = "Cheeseburger", Price = 8 },
                new MenuItem { Id = 4, Name = "Veggie Burger", Price = 7 }
            }
        }
    };

        [HttpGet]
        public IActionResult GetRestaurants()
        {
            return Ok(Restaurants.Select(r => new { r.Id, r.Name }));
        }

        [HttpGet("{id}/menu")]
        public IActionResult GetMenuByRestaurant(int id)
        {
            var restaurant = Restaurants.FirstOrDefault(r => r.Id == id);
            if (restaurant == null)
                return NotFound("Restaurant not found.");

            return Ok(restaurant.Menu);
        }
    }
}