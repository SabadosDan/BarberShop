using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Pages.Appointments
{
    public class IndexModel : PageModel
    {
        private readonly WebAPI.Data.WebAPIContext _context;

        public IndexModel(WebAPI.Data.WebAPIContext context)
        {
            _context = context;
        }

        public IList<Appointment> Appointment { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Appointment = await _context.Appointments
                .Include(a => a.Barber)
                .Include(a => a.Client)
                .Include(a => a.Service).ToListAsync();
        }
    }
}
