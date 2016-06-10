using FlugDemo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlugDemo.Data
{
    public class FlightEfRepository : IFlightRepository
    {
        static FlightEfRepository() {

            using (var ctx = new FlightDbContext()) {
                ctx.Database.EnsureDeleted();
                ctx.Database.EnsureCreated();

                var f1 = new Flight { FlightNumber = "LH4711", Date = DateTime.Now, From = "Graz", To = "Frankfurt" };

                var buchung = new Booking {
                    Datum = DateTime.Now,
                    Flug = f1
                };

                f1.Bookings.Add(buchung);

                ctx.Flights.Add(f1);
                ctx.Flights.Add(new Flight { FlightNumber = "AUA0815", Date = DateTime.Now.AddHours(2), From = "Graz", To = "Kognito" });
                ctx.Flights.Add(new Flight { FlightNumber = "LH4712", Date = DateTime.Now, From = "Graz", To = "Flagranti" });
                ctx.Flights.Add(new Flight { FlightNumber = "LH4713", Date = DateTime.Now.AddHours(3), From = "Graz", To = "Frankfurt" });

                ctx.SaveChanges();
            }
        }

        public List<Flight> FindAll() {
            using (var ctx = new FlightDbContext()) {
                return ctx.Flights.OrderBy(f => f.Id).ToList();
            }
        }

        public Flight FindById(int id) {
            using (var ctx = new FlightDbContext())
            {
                // Include kommt aus: Microsoft.Data.Entity
                return ctx.Flights
                          .Include(f => f.Bookings)
                          .FirstOrDefault(f => f.Id == id);
            }
        }

        public List<Flight> FindByRoute(string von, string nach) {
            using (var ctx = new FlightDbContext())
            {
                return ctx.Flights.Where(f => f.From == von && f.To == nach)
                             .OrderBy(f => f.FlightNumber)
                             .ToList();
            }
        }

        public void Save(Flight f) {

            using (var ctx = new FlightDbContext())
            {
                ctx.Flights.Add(f);
                ctx.SaveChanges();
            }
        }
    }
}
