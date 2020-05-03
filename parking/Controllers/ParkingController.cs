using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using parking.database.Models;

namespace parking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingController : Controller
    {
        private readonly MyWebApiContext _context;

        public ParkingController(MyWebApiContext context)
        {
            _context = context;
        }
        // GET: api/Parking
        [Route("~/api/GetAllParkings")]
        [HttpGet]
        public ActionResult<List<Parking>> GetAllParkings()
        {
            return _context.Parking.ToList();
        }

        // GET: api/Parking/5
        [Route("~/api/GetParking/{id}")]
        [HttpGet("{id}", Name = "GetParking")]
        public ActionResult<Parking> GetParking(int id)
        {
            var parking = _context.Parking.Find(id);
            if (parking == null)
            {
                return NotFound();
            }
            return parking;
        }

        // POST: api/Parking
        [Route("~/api/AddParking")]
        [HttpPost]
        public IActionResult CreateParking([FromBody] Parking parking)
        {
            _context.Add(parking);
            _context.SaveChanges();
            return CreatedAtRoute(nameof(GetParking), new { id = parking.id }, parking);
        }

        // DELETE: api/ApiWithActions/5
        [Route("~/api/DeleteParking/{id}")]
        [HttpDelete("{id}")]
        public ActionResult<Parking> DeleteParking(int id)
        {
            var parking = _context.Parking.Find(id);
            if (parking == null)
            {
                return NotFound();
            }

            _context.Parking.Remove(parking);
            _context.SaveChanges();

            return parking;
        }
    }
}
