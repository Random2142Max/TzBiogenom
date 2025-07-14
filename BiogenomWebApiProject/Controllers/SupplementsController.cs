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
    public class SupplementsController : ControllerBase
    {
        private readonly CompanyContext _context;
        public SupplementsController (CompanyContext context) => _context = context;

        // GET: api/Supplements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Supplement>>> GetAll() =>
            await _context.Supplements.ToListAsync();

        // GET: api/Supplements/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Supplement>> GetById(int id)
        {
            var supplement = await _context.Supplements.FindAsync(id);

            if (supplement == null)
                return NotFound();

            return supplement;
        }
    }
}
