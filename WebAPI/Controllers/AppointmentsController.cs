<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
=======
﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using WebAPI.Data;
using System.Threading.Tasks;
using System.Linq;
>>>>>>> origin/Mobile
using WebAPI.Models;

namespace WebAPI.Controllers
{
<<<<<<< HEAD
    [Route("api/[controller]")]
=======
    [Route("api/appointments")]
>>>>>>> origin/Mobile
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly WebAPIContext _context;

        public AppointmentsController(WebAPIContext context)
        {
            _context = context;
        }

<<<<<<< HEAD
        // GET: api/Appointments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointments()
        {
            return await _context.Appointments.ToListAsync();
        }

        // GET: api/Appointments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Appointment>> GetAppointment(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);

            if (appointment == null)
            {
                return NotFound();
            }

            return appointment;
        }

        // PUT: api/Appointments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppointment(int id, Appointment appointment)
        {
            if (id != appointment.ID)
            {
                return BadRequest();
            }

            _context.Entry(appointment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppointmentExists(id))
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

        // POST: api/Appointments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Appointment>> PostAppointment(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAppointment", new { id = appointment.ID }, appointment);
        }

        // DELETE: api/Appointments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }

            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AppointmentExists(int id)
        {
            return _context.Appointments.Any(e => e.ID == id);
        }
=======
        [HttpGet("available")]
        public async Task<IActionResult> CheckAvailability(int barberId, DateTime dateTime)
        {
            var existingAppointment = await _context.Appointment
                .FirstOrDefaultAsync(a => a.BarberId == barberId && a.DateTime == dateTime);

            if (existingAppointment != null)
            {
                return Ok(false); 
            }

            return Ok(true); 
        }

        [HttpPost]
        public async Task<IActionResult> BookAppointment([FromBody] Appointment appointment)
        {
            if (appointment == null || appointment.Services == null || !appointment.Services.Any())
            {
                return BadRequest("Invalid appointment data.");
            }

            var isAvailable = !await _context.Appointment.AnyAsync(a => a.BarberId == appointment.BarberId && a.DateTime == appointment.DateTime);
            if (!isAvailable)
            {
                return BadRequest("The selected time slot is already reserved.");
            }

            decimal totalPrice = 0;
            foreach (var service in appointment.Services)
            {
                totalPrice += appointment.Price;
            }
            appointment.Price = totalPrice;

            _context.Appointment.Add(appointment);
            await _context.SaveChangesAsync();

            return Ok(new { AppointmentId = appointment.Id });
        }

        [HttpGet("barber/{barberId}")]
        public async Task<IActionResult> GetAppointmentsByBarber(int barberId)
        {
            var appointments = await _context.Appointment
                .Where(a => a.BarberId == barberId)
                .OrderBy(a => a.DateTime)
                .ToListAsync();

            return Ok(appointments);
        }

        [HttpGet("{clientId}")]
        public async Task<IActionResult> GetAppointmentsByClientId(int clientId)
        {
            var appointments = await _context.Appointment
                                              .Where(a => a.ClientId == clientId)
                                              .Include(a => a.Barber) 
                                              .ToListAsync();

            return Ok(appointments);
        }

>>>>>>> origin/Mobile
    }
}
