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
    public class FoodsNutrientsController : ControllerBase
    {
        private readonly CompanyContext _context;
        public FoodsNutrientsController (CompanyContext context) => _context = context;

        // GET: api/FoodsNutrients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoodsNutrient>>> GetAll() =>
            await _context.FoodsNutrients.ToListAsync();

        // GET: api/FoodsNutrients/1
        [HttpGet("{id}")]
        public async Task<ActionResult<FoodsNutrient>> GetById(int id)
        {
            var foodsNutrient = await _context.FoodsNutrients.FindAsync(id);

            if (foodsNutrient == null)
                return NotFound();

            return foodsNutrient;
        }
    }
}
