using FlightWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlightWebApplication.Controllers
{
    public class DisplayFlightDetailsController : Controller
    {
        ApplicationDbContext _db = new ApplicationDbContext();

        // GET: DisplayFlightDetails
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DisplayFlightDetails()
        {
            var display = _db.flightDataset.ToList();
            return View(display);
        }

        [HttpPost]
        public ActionResult DisplayFlightDetails(DisplayUserFlightData AddFlight)
        {
            //ModelState.Clear();
            return RedirectToAction("AddFlightDetails");
        }
    }
}