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

        [HttpGet]
        public ActionResult DisplayFlightDetails()
        {
            if (TempData["test"] != null)
            {
                var item = (List<DisplayFlightViewModel>)TempData["test"];
                return View(item);
            }
            var display = _db.flightDataset.Where(x => x.Delete_Flag == "N").ToList().Select(x => new DisplayFlightViewModel()
            {
                ID = x.ID,
                FlightNumber = x.FlightNumber,
                DestinationName = x.DestinationName,
                FlightDistance = x.FlightDistance,
                FlightPrice = x.FlightPrice,
                DiscountPercentage = x.DiscountPercentage,
                DiscountedAmount = Math.Round((x.FlightPrice * x.DiscountPercentage) / 100),
                TotalAmount = (x.FlightPrice - Math.Round((x.FlightPrice * x.DiscountPercentage) / 100))
            });
            return View(display);
        }

        [HttpPost]
        public ActionResult DisplayFlightDetails(DisplayUserFlightData AddFlight)
        {
            //ModelState.Clear();
            return RedirectToAction("AddFlightDetails");
        }


        //[HttpPost]
        //public ActionResult DiscountedPercentage(DisplayFlightViewModel Dp)
        //{
        //    decimal discountedPrice = Math.Round(Dp.FlightPrice * (Dp.DiscountPercentage / 100m), 2, MidpointRounding.ToEven);
        //    // decimal discountedPrice = originalPrice - markdown;
        //    return discountedPrice;
        //    // return RedirectToAction("DisplayFlightDetails");
        //}

        [HttpPost]
        public ActionResult Find(string searchString)
        {
            string item = searchString;
            var det = _db.flightDataset.Where(x => x.Delete_Flag == "N").ToList().Select(x => new DisplayFlightViewModel()
            {
                ID = x.ID,
                FlightNumber = x.FlightNumber,
                DestinationName = x.DestinationName,
                FlightDistance = x.FlightDistance,
                FlightPrice = x.FlightPrice,
                DiscountPercentage = x.DiscountPercentage,
                DiscountedAmount = Math.Round((x.FlightPrice * x.DiscountPercentage) / 100),
                TotalAmount = (x.FlightPrice - Math.Round((x.FlightPrice * x.DiscountPercentage) / 100))
            });

            if (!String.IsNullOrEmpty(searchString))
            {
                det = det.Where(x => x.FlightNumber.ToString() == item || x.DestinationName == item || x.FlightPrice.ToString() == item).ToList();
            }
            TempData["test"] = det.ToList();
            return RedirectToAction("DisplayFlightDetails");
        }



        [HttpPost]
        public ActionResult SortPrice(string order)
        {
            string item = order;
            var sort = _db.flightDataset.Where(x => x.Delete_Flag == "N").ToList().Select(x => new DisplayFlightViewModel()
            {
                ID = x.ID,
                FlightNumber = x.FlightNumber,
                DestinationName = x.DestinationName,
                FlightDistance = x.FlightDistance,
                FlightPrice = x.FlightPrice,
                DiscountPercentage = x.DiscountPercentage,
                DiscountedAmount = Math.Round((x.FlightPrice * x.DiscountPercentage) / 100),
                TotalAmount = (x.FlightPrice - Math.Round((x.FlightPrice * x.DiscountPercentage) / 100))
            });

            sort = sort.OrderBy(a => a.FlightPrice).ToList();
            //sort.Reverse();
            
            TempData["test"] = sort.ToList();
            return RedirectToAction("DisplayFlightDetails");
        }
    }
}