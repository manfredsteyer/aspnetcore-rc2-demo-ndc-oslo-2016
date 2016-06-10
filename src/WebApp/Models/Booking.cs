using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlugDemo.Models
{

    public class Booking
    {
        public int BookingId { get; set; }
        public DateTime Datum { get; set; }

        public int FlugId { get; set; }
        public Flight Flug { get; set; }

        public int PassagierId { get; set; }

        // public Passagier Passagier { get; set; }
    }
}
