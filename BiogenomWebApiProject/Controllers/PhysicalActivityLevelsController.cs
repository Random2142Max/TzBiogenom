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
    public class PhysicalActivityLevelsController : ControllerBase
    {
        private readonly CompanyContext _context;
        public PhysicalActivityLevelsController (CompanyContext context) => _context = context;

        // GET: api/PhysicalActivityLevels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Physicalactivitylevel>>> GetAll() =>
            await _context.Physicalactivitylevels.ToListAsync();

        // GET: api/Physicalactivitylevel/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Physicalactivitylevel>> GetById(int id)
        {
            var physicalActivityLevel = await _context.Physicalactivitylevels.FindAsync(id);

            if (physicalActivityLevel == null)
                return NotFound();

            return physicalActivityLevel;
        }
    }
}
