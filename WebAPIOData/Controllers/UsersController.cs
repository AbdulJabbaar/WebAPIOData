using System.Linq;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIOData.Data;

namespace WebAPIOData.Controllers
{
    public class UsersController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public UsersController(ApplicationContext context)
        {
            _context = context;
        }

        [EnableQuery()]
        public IActionResult Get()
        {
            return Ok(_context.Users);
        }

        [EnableQuery()]
        public IActionResult Get(int id)
        {
            var user = _context.Users.Include(x=>x.UserClaims).FirstOrDefault(x => x.Id == id);
            if (user != null)
                return Ok(user);
            return NotFound();
        }
    }
}