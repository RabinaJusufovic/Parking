using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using parking.database.Models;

namespace parking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : Controller
    {
        private readonly MyWebApiContext _context;

        public CommentsController(MyWebApiContext context)
        {
            _context = context;
        }

        public ActionResult<Comments> GetComment(int id)
        {
            var comment = _context.Comments.Find(id);
            if (comment == null)
            {
                return NotFound();
            }
            return comment;
        }

        // DELETE api/comment/id
        [Route("~/api/DeleteComment/{id}")]
        [HttpDelete("{id}")]
        public ActionResult<Comments> DeleteComment(int id)
        {
            var comment = _context.Comments.Find(id);
            if (comment == null)
            {
                return NotFound();
            }

            _context.Comments.Remove(comment);
            _context.SaveChanges();

            return comment;
        }

        // GET: api/comment
        [Route("~/api/GetAllComments")]
        [HttpGet]
        public ActionResult<List<Comments>> GetAllComments()
        {
            return _context.Comments.ToList();
        }
    }
}