using CloudinaryDotNet;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ourstars_back.Data;

namespace ourstars_back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly Cloudinary _cloudinary;

        public ReviewController(AppDbContext context, IConfiguration config)
        {
            _context = context;
            var account = new Account(
                config["CloudinarySettings:CloudName"],
                config["CloudinarySettings:ApiKey"],
                config["CloudinarySettings:ApiSecret"]
            );
            _cloudinary = new Cloudinary(account);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? userId)
        {
            var query = _context.Reviews.AsQueryable();

            if (!string.IsNullOrEmpty(userId))
            {
                query = query.Where(r => r.OwnerId == userId || r.TaggedUserId == userId);
            }

            var reviews = await query
                .OrderByDescending(r => r.CreatedAt)
                .ToListAsync();

            return Ok(reviews);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateReviewDto dto)
        {

        }
    }
}
