﻿using System.ComponentModel.DataAnnotations;

namespace Flights.Models
{
    public class Reservation
    {

        [Key]
        public string ReservationID { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public int MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "It has to be 10 characters.")]
        public string EGN { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string TicketType { get; set; }

        public virtual Flight Flight { get; set; }
        //[Required]
        //public int NumberOfTickets { get; set; }
    }
}
