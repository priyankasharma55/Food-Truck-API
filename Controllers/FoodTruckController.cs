using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Food_Truck_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FoodTruckController : ControllerBase
    {
        private readonly ILogger<FoodTruckController> _logger;
        private readonly Nearby nearby;

        public FoodTruckController(ILogger<FoodTruckController> logger)
        {
            _logger = logger;
            nearby = new Nearby();
        }

        [HttpPost("GetFoodTrucks")]
        [Produces("application/json")]
        public IActionResult GetFoodTrucks([FromBody] Coordinate coordinate)
        {
            var result = JsonConvert.SerializeObject(nearby.GetNearestFoodTrucks(coordinate.Longitude, coordinate.Latitude), Formatting.Indented);
            return new OkObjectResult(result);
        }
    }
}