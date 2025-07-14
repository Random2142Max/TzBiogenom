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
    public class SetNutrientsController : ControllerBase
    {
        private readonly CompanyContext _context;
        public SetNutrientsController (CompanyContext context) => _context = context;

        // GET: api/Setnutrients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Setnutrient>>> GetAll() =>
            await _context.Setnutrients.ToListAsync();

        // GET: api/Setnutrients/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Setnutrient>> GetById(int id)
        {
            var setNutrient = await _context.Setnutrients.FindAsync(id);

            if (setNutrient == null)
                return NotFound();

            return setNutrient;
        }
    }
}
