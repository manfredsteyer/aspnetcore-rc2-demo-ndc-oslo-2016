using FlugDemo.Data;
using FlugDemo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SummitDemo.ActionResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SummitDemo.Controllers
{
    [Route("api/[controller]")]
    public class FlightController: Controller
    {
        IFlightRepository repo;

        public FlightController(IFlightRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public List<Flight> GetAll() {
            return this.repo.FindAll();
        }

        [HttpGet("{id}")]
        public Flight GetById(int id) {
            return this.repo.FindById(id);
        }

        [HttpGet("byRoute")]
        public List<Flight> GetByRoute(string from, string to) {
            return this.repo.FindByRoute(from, to);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Flight flight) {
            this.repo.Save(flight);

            //return flight;
            
            return CreatedAtAction("GetById", new { id = flight.Id  }, flight);
        }
    }
}
