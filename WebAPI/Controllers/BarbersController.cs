<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
=======
﻿using Microsoft.AspNetCore.Mvc;
>>>>>>> origin/Mobile
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarbersController : ControllerBase
    {
        private readonly WebAPIContext _context;

        public BarbersController(WebAPIContext context)
        {
            _context = context;
        }

        // GET: api/Barbers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Barber>>> GetBarbers()
        {
<<<<<<< HEAD
            return await _context.Barbers.ToListAsync();
=======
            return await _context.Barbers.Include(b => b.Services).ToListAsync();
>>>>>>> origin/Mobile
        }

        // GET: api/Barbers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Barber>> GetBarber(int id)
        {
<<<<<<< HEAD
            var barber = await _context.Barbers.FindAsync(id);
=======
            var barber = await _context.Barbers.Include(b => b.Services).FirstOrDefaultAsync(b => b.Id == id);
>>>>>>> origin/Mobile

            if (barber == null)
            {
                return NotFound();
            }

            return barber;
        }

<<<<<<< HEAD
        // PUT: api/Barbers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBarber(int id, Barber barber)
        {
            if (id != barber.ID)
=======
        // POST: api/Barbers
        [HttpPost]
        public async Task<ActionResult<Barber>> PostBarber(Barber barber)
        {
            _context.Barbers.Add(barber);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBarber", new { id = barber.Id }, barber);
        }

        // PUT: api/Barbers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBarber(int id, Barber barber)
        {
            if (id != barber.Id)
>>>>>>> origin/Mobile
            {
                return BadRequest();
            }

            _context.Entry(barber).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BarberExists(id))
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

<<<<<<< HEAD
        // POST: api/Barbers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Barber>> PostBarber(Barber barber)
        {
            _context.Barbers.Add(barber);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBarber", new { id = barber.ID }, barber);
        }

=======
>>>>>>> origin/Mobile
        // DELETE: api/Barbers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBarber(int id)
        {
            var barber = await _context.Barbers.FindAsync(id);
            if (barber == null)
            {
                return NotFound();
            }

            _context.Barbers.Remove(barber);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BarberExists(int id)
        {
<<<<<<< HEAD
            return _context.Barbers.Any(e => e.ID == id);
=======
            return _context.Barbers.Any(e => e.Id == id);
>>>>>>> origin/Mobile
        }
    }
}
