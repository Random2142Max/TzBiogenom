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
    public class AssessmentsController : ControllerBase
    {
        private readonly CompanyContext _context;
        public AssessmentsController(CompanyContext context) => _context = context;

        // GET: api/Assessments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Assessment>>> GetAll() =>
            await _context.Assessments.ToListAsync();

        // GET: api/Assessments/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Assessment>> GetById(int id)
        {
            var assessments = await _context.Assessments.FindAsync(id);

            if (assessments == null)
                return NotFound();

            return assessments;
        }
    }
}
