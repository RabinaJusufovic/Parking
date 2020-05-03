using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using parking.database.Models;

namespace parking.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
    public class ReserveController : Controller
    {
		private readonly MyWebApiContext _context;

		public ReserveController(MyWebApiContext context)
		{
			_context = context;
		}
		[Route("~/api/GetAllReservedParkings")]
		[HttpGet]
		public ActionResult<List<Reserve>> GetAllReservedParkings()
		{
			return _context.Reserve.ToList();
		}


		// DELETE api/reserve/id
		[Route("~/api/DeleteReservedParking/{id}")]
		[HttpDelete("{id}")]
		public ActionResult<Reserve> DeleteReservedParking(int id)
		{
			var reserved = _context.Reserve.Find(id);
			if (reserved == null)
			{
				return NotFound();
			}

			_context.Reserve.Remove(reserved);
			_context.SaveChanges();

			return reserved;
		}

		//GET api/reserve/id
		[Route("~/api/GetReservedParking/{id}")]
		[HttpGet("{id}", Name = "GetReservedParking")]
		public ActionResult<Reserve> GetReservedParking(int id)
		{
			var reserved = _context.Reserve.Find(id);
			if (reserved == null)
			{
				return NotFound();
			}
			return reserved;
		}
	}
}