using FlightWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FlightWebApplication.Controllers
{
    public class SearchController : Controller
    {
        [HttpPost]
        public ActionResult Search(string searchString)
        {
            string item = searchString;
            var det = _db.flightDataset.ToList();

            if (!String.IsNullOrEmpty(searchString))
            {
                det = det.Where(x => x.FlightNumber.ToString() == item || x.DestinationName == item || x.FlightPrice.ToString() == item).ToList();
            }
            TempData["test"] = det.ToList();
            return RedirectToAction("DisplayFlightDetails");
        }
    }
}