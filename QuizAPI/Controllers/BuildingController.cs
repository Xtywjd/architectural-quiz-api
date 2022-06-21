using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizAPI.Data;
using QuizAPI.Models;

namespace QuizAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingController : ControllerBase
    {
        private readonly DataContext _context;

        public BuildingController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Building>>> Get()
        {
            return await _context.Buildings.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Building>> Get(int id)
        {
            var building = await _context.Buildings.FindAsync(id);

            return building == null ? NotFound() : building;
        }

        [HttpGet("getRandomBuildings/{count}")]
        public async Task<ActionResult<List<Building>>> GetRandomBuildings(int count)
        {
            var randomBuildings = new List<Building>();

            while (randomBuildings.Count < _context.Buildings.Count() &&
                   randomBuildings.Count < count)
            {
                var building = _context.Buildings.Find(new Random().Next(1, _context.Buildings.Count() + 1));
                if (building != null && !randomBuildings.Contains(building))
                    randomBuildings.Add(building);
            }

            return randomBuildings;
        }
    }
}
