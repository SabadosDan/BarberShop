using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using WebAPI.Data;
using System.Threading.Tasks;
using System.Linq;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/appointments")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly WebAPIContext _context;

        public AppointmentsController(WebAPIContext context)
        {
            _context = context;
        }

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

    }
}
