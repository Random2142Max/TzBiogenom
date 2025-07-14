using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BiogenomWebApiProject.Models.Data;
using BiogenomWebApiProject.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiogenomWebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly CompanyContext _context;
        public UsersController(CompanyContext context) => _context = context;

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAll() =>
            await _context.Users.ToListAsync();

        // GET: api/Users/1
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetById(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
                return NotFound();

            return user;
        }
    }
}
