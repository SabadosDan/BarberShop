using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly WebAPIContext _context;

        public ReviewsController(WebAPIContext context)
        {
            _context = context;
        }

        // GET: api/Reviews/{barberId}
        [HttpGet("{barberId}")]
        public async Task<ActionResult<IEnumerable<Review>>> GetReviewsByBarberId(int barberId)
        {
            var reviews = await _context.Reviews
                                        .Where(r => r.BarberId == barberId)
                                        .ToListAsync();

            if (reviews == null || !reviews.Any())
            {
                return NotFound("No reviews found for this barber.");
            }

            return Ok(reviews);
        }

        // POST: api/Reviews
        [HttpPost]
        public async Task<ActionResult<Review>> PostReview(Review review)
        {
            if (review == null || review.BarberId <= 0 || review.Rating < 1 || review.Rating > 5)
            {
                return BadRequest("Invalid review data.");
            }

            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetReviewsByBarberId), new { barberId = review.BarberId }, review);
        }

        // GET: api/Reviews/{barberId}
        [HttpGet("Rating/{barberId}")]
        public async Task<ActionResult<IEnumerable<int>>> GetAllRatings(int barberId)
        {
            var ratings = await _context.Reviews
                                         .Where(r => r.BarberId == barberId)
                                         .Select(r => r.Rating) 
                                         .ToListAsync();        

            if (ratings == null || !ratings.Any())
            {
                return NotFound("No ratings found for this barber.");
            }

            return Ok(ratings);
        }



        // DELETE: api/Reviews/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            var review = await _context.Reviews.FindAsync(id);
            if (review == null)
            {
                return NotFound("Review not found.");
            }

            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
