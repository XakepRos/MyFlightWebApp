using FlightWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlightWebApplication.Controllers
{
    public class AddFlightController : Controller
    {
        ApplicationDbContext _db = new ApplicationDbContext();
        //Repository dinnerRepository = new DinnerRepository();


        //GET: Flight
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult AddFlightDetails()
        {
            return View();
        }
        //POST: Flight
        [HttpPost]
        public ActionResult AddFlightDetails(AddFlightData AddFlight)
        {
            if (ModelState.IsValid)
            {
                AddFlight.Delete_Flag = "N";
                _db.flightDataset.Add(AddFlight);
                _db.SaveChanges();
            }
            else
            {
                return View();
            }
            //ModelState.Clear();
            return RedirectToAction("AddFlightDetails");
        }


        // GET: /Movies/Edit/5
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            AddFlightData edit = _db.flightDataset.Find(Id);
            if (edit == null)
            {
                return HttpNotFound();
            }
            return View(edit);
        }
        // POST: /Movies/Edit/5
        [HttpPost]
        public ActionResult Edit(AddFlightData edit)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(edit).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("DisplayFlightDetails", "DisplayFlightDetails");
            }
            return View(edit);
        }



        // HTTP GET: /Dinners/Delete/1 
        [HttpGet]
        public ActionResult DeleteData(int Id)
        {
            AddFlightData delete = _db.flightDataset.Where(x => x.ID == Id).FirstOrDefault();

            if (delete == null)
            {
                throw new NotImplementedException();
            }
            else
            {
                delete.Delete_Flag = "Y";
              //  _db.flightDataset.up(delete);
                _db.SaveChanges();
                return RedirectToAction("DisplayFlightDetails", "DisplayFlightDetails");
            }
        }
    }
}