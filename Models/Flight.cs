﻿using System.ComponentModel.DataAnnotations;

namespace Flights.Models
{
    public class Flight
    {
        [Key]
        public int FlightID { get; set; }

        [Required]
        public string StartLocation { get; set; }

        [Required]
        public string EndLocation { get; set; }

        [Required]
        [DateGreaterThanToday]
        public DateTime StartDateTime { get; set; }

        [Required]
        [DateGreaterThanToday]
        public DateTime EndDateTime { get; set; }

        [Required]
        public string PilotName { get; set; }

        [Required]
        public int PlaneID { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
