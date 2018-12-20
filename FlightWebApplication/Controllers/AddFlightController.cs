using FlightWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlightWebApplication.Controllers
{
    public class AddFlightController : Controller
    {
        ApplicationDbContext _db = new ApplicationDbContext();
        //GET: Flight
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddFlightDetails()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddFlightDetails(AddFlightData AddFlight)
        {
            if (ModelState.IsValid)
            {
                _db.flightDataset.Add(AddFlight);
                _db.SaveChanges();
            }
            //ModelState.Clear();
            return RedirectToAction("AddFlightDetails");
        }







        public ActionResult AddDiscountPercentage()
        {
            return View();
        }
        public ActionResult DisplayFlightDetails()
        {
            return View();
        }
        public ActionResult Search()
        {
            return View();
        }
        public ActionResult DBUser()
        {
            return View();
        }
        public ActionResult ReadDB()
        {
            return View();
        }
        public ActionResult DBPlay()
        {
            return View();
        }
    }
}