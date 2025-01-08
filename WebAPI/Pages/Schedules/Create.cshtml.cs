using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Pages.Schedules
{
    public class CreateModel : PageModel
    {
        private readonly WebAPI.Data.WebAPIContext _context;

        public CreateModel(WebAPI.Data.WebAPIContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["BarberID"] = new SelectList(_context.Barbers, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public Schedule Schedule { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Schedules.Add(Schedule);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
