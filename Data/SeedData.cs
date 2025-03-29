using Microsoft.EntityFrameworkCore;
using Flights.Models;

namespace Flights.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new FlightsContext(
            serviceProvider.GetRequiredService<
                    DbContextOptions<FlightsContext>>()))
            {
                // Проверява за самолети
                if (context.Plane.Any())
                {
                    return;   // Списъкът със самолети вече е запълнен
                }
                context.Plane.AddRange(
                    new Plane
                    {
                        Company = "Wizz",
                        MaxSeats = 100,
                        MaxBusinessSeats = 20
                    },
                    new Plane
                    {
                        Company = "Wizz",
                        MaxSeats = 200,
                        MaxBusinessSeats = 30
                    },
                    new Plane
                    {
                        Company = "Rayan",
                        MaxSeats = 100,
                        MaxBusinessSeats = 20
                    },
                    new Plane
                    {
                        Company = "Wizz",
                        MaxSeats = 180,
                        MaxBusinessSeats = 0
                    },
                    new Plane
                    {
                        Company = "Delta",
                        MaxSeats = 16,
                        MaxBusinessSeats = 108
                    });
                context.SaveChanges();
            }
        }
    }
}
