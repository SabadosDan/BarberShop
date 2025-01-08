using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Pages.Reviews
{
    public class IndexModel : PageModel
    {
        private readonly WebAPI.Data.WebAPIContext _context;

        public IndexModel(WebAPI.Data.WebAPIContext context)
        {
            _context = context;
        }

        public IList<Review> Review { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Review = await _context.Reviews
                .Include(r => r.Barber)
                .Include(r => r.Client).ToListAsync();
        }
    }
}
