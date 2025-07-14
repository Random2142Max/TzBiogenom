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
    public class CurrentDailyConsumptionsController : ControllerBase
    {
        private readonly CompanyContext _context;
        public CurrentDailyConsumptionsController(CompanyContext context) => _context = context;

        // GET: api/CurrentDailyConsumptions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Currentdailyconsumption>>> GetAll() =>
            await _context.Currentdailyconsumptions.ToListAsync();

        // GET: api/CurrentDailyConsumptions/2
        [HttpGet("{Id}")]
        public async Task<ActionResult<Currentdailyconsumption>> GetById(int id)
        {
            var consumptions = await _context.Currentdailyconsumptions.FindAsync(id);

            if (consumptions == null)
                return NotFound();

            return consumptions;
        }
    }
}
