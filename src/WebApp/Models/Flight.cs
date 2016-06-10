using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace FlugDemo.Models
{
    public class Flight
    {
        public int Id { get; set; }

        [MaxLength(30)]
        [Required]
        public string From { get; set; }

        [MaxLength(30)]
        [Required]
        public string To { get; set; }

        public DateTime Date { get; set; }

        [MaxLength(30)]
        [Required]
        public string FlightNumber { get; set; }

        public List<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
