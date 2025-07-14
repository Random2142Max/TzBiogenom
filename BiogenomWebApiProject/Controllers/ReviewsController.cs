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
    public class ReviewsController : ControllerBase
    {
        private readonly CompanyContext _context;
        public ReviewsController (CompanyContext context) => _context = context;

        // GET: api/Reviews
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Review>>> GetAll() =>
            await _context.Reviews.ToListAsync();

        // GET: api/Reviews/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Review>> GetById(int id)
        {
            var review = await _context.Reviews.FindAsync(id);

            if (review == null)
                return NotFound();

            return review;
        }
    }
}
