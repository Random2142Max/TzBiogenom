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
    public class NutrientsSupplementsController : ControllerBase
    {
        private readonly CompanyContext _context;
        public NutrientsSupplementsController (CompanyContext context) => _context = context;

        // GET: api/NutrientsSupplements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NutrientsSupplement>>> GetAll() =>
            await _context.NutrientsSupplements.ToListAsync();

        // GET: api/NutrientsSupplements/1
        [HttpGet("{id}")]
        public async Task<ActionResult<NutrientsSupplement>> GetById(int id)
        {
            var nutrientsSupplement = await _context.NutrientsSupplements.FindAsync(id);

            if (nutrientsSupplement == null)
                return NotFound();

            return nutrientsSupplement;
        }
    }
}
