using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Pages.Barbers
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly WebAPI.Data.WebAPIContext _context;

        public CreateModel(WebAPI.Data.WebAPIContext context)
        {
            _context = context;
        }

        [BindProperty] // This property binds the form data to the Razor Page
        public Barber Barber { get; set; } = default!; // Bind the form data to the Barber property


        public IActionResult OnGet()
        {
            return Page();
        }


        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    // Log why the model state is invalid
                    foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                    {
                        Console.WriteLine($"ModelState Error: {error.ErrorMessage}");
                    }

                    return Page();
                }

                Console.WriteLine($"FirstName: {Barber.FirstName}, LastName: {Barber.LastName}");

                _context.Barbers.Add(Barber);
                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                // Log exception details
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine(ex.StackTrace);

                throw; // Re-throw the exception for better visibility in the browser
            }
        }

    }
}
