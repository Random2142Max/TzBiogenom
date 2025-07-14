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
    public class NewConsumptionsController : ControllerBase
    {
        private readonly CompanyContext _context;
        public NewConsumptionsController (CompanyContext context) => _context = context;

        // GET: api/Newconsumptions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Newconsumption>>> GetAll() =>
            await _context.Newconsumptions.ToListAsync();

        // GET: api/Newconsumptions/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Newconsumption>> GetById(int id)
        {
            var newConsumption = await _context.Newconsumptions.FindAsync(id);

            if (newConsumption == null)
                return NotFound();

            return newConsumption;
        }
    }
}
