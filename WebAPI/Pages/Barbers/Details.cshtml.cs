﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Pages.Barbers
{
    public class DetailsModel : PageModel
    {
        private readonly WebAPI.Data.WebAPIContext _context;

        public DetailsModel(WebAPI.Data.WebAPIContext context)
        {
            _context = context;
        }

        public Barber Barber { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var barber = await _context.Barbers.FirstOrDefaultAsync(m => m.ID == id);
            if (barber == null)
            {
                return NotFound();
            }
            else
            {
                Barber = barber;
            }
            return Page();
        }
    }
}