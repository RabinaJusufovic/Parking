using Microsoft.AspNetCore.Mvc;
using parking.database.Models;

namespace parking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteController : Controller
    {
        private readonly MyWebApiContext _context;

        public FavoriteController(MyWebApiContext context)
        {
            _context = context;
        }

        // DELETE api/favorite/id
        [Route("~/api/DeleteFavorite/{id}")]
        [HttpDelete("{id}")]
        public ActionResult<Favorite> DeleteFavorite(int id)
        {
            var favorite = _context.Favorite.Find(id);
            if (favorite == null)
            {
                return NotFound();
            }

            _context.Favorite.Remove(favorite);
            _context.SaveChanges();

            return favorite;
        }
    }
}