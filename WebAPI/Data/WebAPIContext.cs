using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class WebAPIContext : DbContext
    {
        public WebAPIContext (DbContextOptions<WebAPIContext> options)
            : base(options)
        {
        }

        public DbSet<WebAPI.Models.Clients> Clients { get; set; } = default!;
        public DbSet<WebAPI.Models.Barber> Barbers { get; set; } = default!;
        public DbSet<WebAPI.Models.Service> Services { get; set; } = default!;
        public DbSet<WebAPI.Models.Appointment> Appointment { get; set; } = default!;
    }
}
