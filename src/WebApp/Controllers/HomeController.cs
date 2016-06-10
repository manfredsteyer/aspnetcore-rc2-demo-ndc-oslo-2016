using FlugDemo.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SummitDemo.Controllers
{
    
    public class HomeController: Controller
    {
        private IFlightRepository repo;

        public HomeController(IFlightRepository repo, ILogger<HomeController> logger)
        {
            this.repo = repo;
            logger.LogDebug("Manfred was here ... ");
            logger.LogDebug("... and you've been haaaaacked, you §$%&/()=?");

        }

        public IActionResult Index() {
            var all = this.repo.FindAll();
            return View("List", all); 
        }

        public IActionResult Detail(int id) {
            var flug = this.repo.FindById(id);
            return View("Detail", flug);
        }

        public IActionResult About() {
            return View();
        }

        public IActionResult Contact() {
            return View();
        }

    }
}
