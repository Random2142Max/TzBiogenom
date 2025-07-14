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
    public class NutrientsController : ControllerBase
    {
        private readonly CompanyContext _context;
        public NutrientsController(CompanyContext context) => _context = context;

        // GET: api/Nutrients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Nutrient>>> GetAll() =>
            await _context.Nutrients.ToListAsync();

        // GET: api/Nutrients/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Nutrient>> GetById(int id)
        {
            var nutrient = await _context.Nutrients.FindAsync(id);

            if (nutrient == null)
                return NotFound();

            return nutrient;
        }
    }
}
