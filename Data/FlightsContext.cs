using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Flights.Models;

namespace Flights.Data
{
    public class FlightsContext : DbContext
    {
        public FlightsContext (DbContextOptions<FlightsContext> options)
            : base(options)
        {
        }

        public DbSet<Flights.Models.Flight> Flight { get; set; } = default!;
        public DbSet<Flights.Models.Plane> Plane { get; set; } = default!;
        public DbSet<Flights.Models.Reservation> Reservation { get; set; } = default!;

        //promqna
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Flight)
                .WithMany(b => b.Reservations)
                .HasForeignKey(r => r.FlightID);

            //modelBuilder.Entity<Flight>()
            //    .HasOne(f => f.Plane)
            //    .WithMany(p => p.Flights)
            //    .HasForeignKey(f => f.PlaneID);
        }
    }
}
