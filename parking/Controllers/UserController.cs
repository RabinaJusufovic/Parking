using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using parking.database.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace parking.Controllers
{
    [Route("api/UserController")]
    public class UserController : Controller
    {
        private readonly MyWebApiContext _context;

        public UserController(MyWebApiContext context)
        {
            _context = context;
        }
        // GET: api/user
        [Route("~/api/GetAllUsers")]
        [HttpGet]
        public ActionResult<List<User>> GetAllUsers()
        {
            return _context.User.ToList();
        }

        // GET api/user/id
        [Route("~/api/GetUserById/{id}")]
        [HttpGet("{id}", Name ="GetUser")]
        public ActionResult<User> GetUserById(int id)
        {
            var user = _context.User.Find(id);
            if(user == null)
            {
                return NotFound();
            }
            return user;
        }

        // POST api/user
        [Route("~/api/AddUser")]
        [HttpPost]
        public IActionResult CreateUser([FromBody]User user)
        {
            _context.Add(user);
            _context.SaveChanges();
            return CreatedAtRoute(nameof(GetUserById), new { id = user.id }, user);
        }

        // PUT api/user/id
        [Route("~/api/UpdateUser/{id}")]
        [HttpPut("{id}")]
        public IActionResult PutUser(int id, [FromBody]User user)
        {
            if(id != user.id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch(DbUpdateConcurrencyException)
            {
                if(_context.User.Find(id)==null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE api/user/id
        [Route("~/api/DeleteUser/{id}")]
        [HttpDelete("{id}")]
        public ActionResult<User> DeleteUser(int id)
        {
            var user = _context.User.Find(id);
            if(user==null)
            {
                return NotFound();
            }

            _context.User.Remove(user);
            _context.SaveChanges();

            return user;
        }
    }
}
