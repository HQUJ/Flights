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
    }
}
