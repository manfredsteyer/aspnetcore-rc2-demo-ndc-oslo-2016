using FlugDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlugDemo.Data
{
    public class FlightDemoRepository : IFlightRepository
    {
        static List<Flight> fluege;

        static FlightDemoRepository() {
            fluege = new List<Flight>();

            fluege.Add(new Flight { Id = 1, FlightNumber = "LH4711", Date = DateTime.Now, From = "Graz", To = "Frankfurt" });
            fluege.Add(new Flight { Id = 2, FlightNumber = "AUA0815", Date = DateTime.Now.AddHours(2), From = "Graz", To = "Kognito" });
            fluege.Add(new Flight { Id = 3, FlightNumber = "LH4712", Date = DateTime.Now, From = "Graz", To = "Flagranti" });
            fluege.Add(new Flight { Id = 4, FlightNumber = "LH4713", Date = DateTime.Now.AddHours(3), From = "Graz", To = "Frankfurt" });

        }

        public List<Flight> FindAll() {
            return fluege.OrderBy(f => f.Id).ToList(); ;
        }

        public Flight FindById(int id) {
            return fluege.FirstOrDefault(f => f.Id == id);
        }

        public List<Flight> FindByRoute(string von, string nach) {
            return fluege.Where(f => f.From == von && f.To == nach)
                         .OrderBy(f => f.FlightNumber)
                         .ToList();
        }

        public void Save(Flight f) {

            // INSERT ?
            if (f.Id == 0) {
                f.Id = fluege.Max(flg => flg.Id) + 1;
                fluege.Add(f);
                return;
            }

            // Update
            var flugInDb = FindById(f.Id);
            flugInDb.From = f.From;
            flugInDb.To = f.To;
            flugInDb.FlightNumber = f.FlightNumber;
            flugInDb.Date = f.Date;

        }

    }
}
