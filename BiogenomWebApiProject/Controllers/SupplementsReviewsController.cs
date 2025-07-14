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
    public class SupplementsReviewsController : ControllerBase
    {
        private readonly CompanyContext _context;
        public SupplementsReviewsController (CompanyContext context) => _context = context;

        // GET: api/SupplementsReviews
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SupplementsReview>>> GetAll() =>
            await _context.SupplementsReviews.ToListAsync();

        // GET: api/SupplementsReviews/1
        [HttpGet("{id}")]
        public async Task<ActionResult<SupplementsReview>> GetById(int id)
        {
            var supplementsReviews = await _context.SupplementsReviews.FindAsync(id);

            if (supplementsReviews == null)
                return NotFound();

            return supplementsReviews;
        }
    }
}
