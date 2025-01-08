using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace WebAPI.Data
{
    public class WebAPIContext : IdentityDbContext<IdentityUser>
    {
        public WebAPIContext (DbContextOptions<WebAPIContext> options)
            : base(options)
        {
        }

<<<<<<< HEAD
        public DbSet<WebAPI.Models.Client> Clients { get; set; } = default!;
        public DbSet<Barber> Barbers { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Schedule> Schedules { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Service>()
        //        .HasMany(s => s.Barbers)
        //        .WithMany(b => b.Services)
        //        .UsingEntity(j => j.ToTable("BarberServices"));
        //}
=======
        public DbSet<WebAPI.Models.Clients> Clients { get; set; } = default!;
        public DbSet<WebAPI.Models.Barber> Barbers { get; set; } = default!;
        public DbSet<WebAPI.Models.Service> Services { get; set; } = default!;
        public DbSet<WebAPI.Models.Appointment> Appointment { get; set; } = default!;
        public DbSet<WebAPI.Models.Review> Reviews { get; set; } = default!;
>>>>>>> origin/Mobile
    }
}
