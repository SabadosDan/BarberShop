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
    public class ServicesController : ControllerBase
    {
        private readonly WebAPIContext _context;

        public ServicesController(WebAPIContext context)
        {
            _context = context;
        }

        // GET: api/Services
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Service>>> GetServices()
        {
<<<<<<< HEAD
            return await _context.Services.ToListAsync();
=======
            return await _context.Services.Include(s => s.Barber).ToListAsync();
>>>>>>> origin/Mobile
        }

        // GET: api/Services/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Service>> GetService(int id)
        {
<<<<<<< HEAD
            var service = await _context.Services.FindAsync(id);
=======
            var service = await _context.Services.Include(s => s.Barber).FirstOrDefaultAsync(s => s.Id == id);
>>>>>>> origin/Mobile

            if (service == null)
            {
                return NotFound();
            }

            return service;
        }

<<<<<<< HEAD
        // PUT: api/Services/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutService(int id, Service service)
        {
            if (id != service.ID)
=======
        // GET: api/Services/barber/barberId
        [HttpGet("barber/{barberId}")]
        public async Task<IActionResult> GetServicesByBarberId(int barberId)
        {
            try
            {
                var services = await _context.Services
                                             .Where(s => s.BarberId == barberId)
                                             .ToListAsync();

                if (services == null || !services.Any())
                {
                    return NotFound(new { Message = "No services found for the specified barber." });
                }

                return Ok(services);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred.", Error = ex.Message });
            }
        }


        // POST: api/Services
        [HttpPost]
        public async Task<ActionResult<Service>> PostService(Service service)
        {

            if (service == null || service.BarberId == null)
            {
                return BadRequest("Service or BarberId is invalid.");
            }

            var barber = await _context.Barbers.FindAsync(service.BarberId);
            if (barber == null)
            {
                return BadRequest("Barber not found.");
            }

            _context.Services.Add(service);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetService", new { id = service.Id }, service);
        }

        // PUT: api/Services/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutService(int id, Service service)
        {
            if (id != service.Id)
>>>>>>> origin/Mobile
            {
                return BadRequest();
            }

            _context.Entry(service).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceExists(id))
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
        // POST: api/Services
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Service>> PostService(Service service)
        {
            _context.Services.Add(service);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetService", new { id = service.ID }, service);
        }

=======
>>>>>>> origin/Mobile
        // DELETE: api/Services/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            var service = await _context.Services.FindAsync(id);
            if (service == null)
            {
                return NotFound();
            }

            _context.Services.Remove(service);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServiceExists(int id)
        {
<<<<<<< HEAD
            return _context.Services.Any(e => e.ID == id);
=======
            return _context.Services.Any(e => e.Id == id);
>>>>>>> origin/Mobile
        }
    }
}
