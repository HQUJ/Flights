using System.ComponentModel.DataAnnotations;

namespace Flights.Models
{
    public class Plane
    {
        [Key]
        public int PlaneID { get; set; }

        public string Company { get; set; }
        public int MaxSeats { get; set; }
        public int MaxBusinessSeats { get; set; }
    }
}
