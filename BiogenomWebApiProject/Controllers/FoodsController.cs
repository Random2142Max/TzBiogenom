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
    public class FoodsController : ControllerBase
    {
        private readonly CompanyContext _context;
        public FoodsController(CompanyContext context) => _context = context;

        // GET: api/Foods
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Food>>> GetAll() =>
            await _context.Foods.ToListAsync();

        // GET: api/Foods/2
        [HttpGet("{id}")]
        public async Task<ActionResult<Food>> GetById(int id)
        {
            var foods = await _context.Foods.FindAsync(id);

            if (foods == null)
                return NotFound();

            return foods;
        }
    }
}
