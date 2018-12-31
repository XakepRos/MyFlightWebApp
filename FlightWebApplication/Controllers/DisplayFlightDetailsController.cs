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

        //GET: DisplayFlightDetails
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Find(string searchString)
        {
            string item =searchString;
            var det = _db.flightDataset.ToList();

            if (!String.IsNullOrEmpty(searchString))
            {
                det = det.Where(x => x.FlightNumber.ToString() == item || x.DestinationName == item || x.FlightPrice.ToString() == item).ToList();           
            }
            TempData["test"] = det.ToList()  ;
            return RedirectToAction("DisplayFlightDetails");
        }

        [HttpGet]
        public ActionResult DisplayFlightDetails()
        {
            if(TempData["test"]!=null)
            {
                var item =(List<AddFlightData>)TempData["test"];
                return View(item);
            }
            var display = _db.flightDataset.ToList();           
            return View(display);
        }

        [HttpPost]
        public ActionResult DisplayFlightDetails(DisplayUserFlightData AddFlight)
        {
            //ModelState.Clear();
            return RedirectToAction("AddFlightDetails");
        }      

        [HttpPost]
        public ActionResult SortPrice(string order)
        {
            string item = order;
            var sort = _db.flightDataset.ToList();                      
            sort = _db.flightDataset.OrderByDescending(a => a.FlightPrice).ToList();
            sort.Reverse();            
            TempData["test"] = sort.ToList();
            return RedirectToAction("DisplayFlightDetails");
        }
    }
}