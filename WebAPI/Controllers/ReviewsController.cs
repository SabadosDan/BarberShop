<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;
=======
﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
>>>>>>> origin/Mobile

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

<<<<<<< HEAD
        // GET: api/Reviews
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Review>>> GetReviews()
        {
            return await _context.Reviews.ToListAsync();
        }

        // GET: api/Reviews/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Review>> GetReview(int id)
        {
            var review = await _context.Reviews.FindAsync(id);

            if (review == null)
            {
                return NotFound();
            }

            return review;
        }

        // PUT: api/Reviews/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReview(int id, Review review)
        {
            if (id != review.ID)
            {
                return BadRequest();
            }

            _context.Entry(review).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReviewExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Reviews
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Review>> PostReview(Review review)
        {
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReview", new { id = review.ID }, review);
        }

        // DELETE: api/Reviews/5
=======
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
>>>>>>> origin/Mobile
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            var review = await _context.Reviews.FindAsync(id);
            if (review == null)
            {
<<<<<<< HEAD
                return NotFound();
=======
                return NotFound("Review not found.");
>>>>>>> origin/Mobile
            }

            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();

            return NoContent();
        }
<<<<<<< HEAD

        private bool ReviewExists(int id)
        {
            return _context.Reviews.Any(e => e.ID == id);
        }
=======
>>>>>>> origin/Mobile
    }
}
