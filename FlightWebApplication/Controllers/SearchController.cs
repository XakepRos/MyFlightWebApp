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
        //GET: Search
        public ActionResult Index()
        {
            SearchFlightData searchflighData = new SearchFlightData();
            return View(searchflighData);
        }


        ApplicationDbContext _Db = new ApplicationDbContext();
        // GET: Search
        [HttpPost]
        public ActionResult Index(SearchFlightData datas)
        {
            // Use LINQ to get list of genres.
            SearchFlightData data = new SearchFlightData();
            List<AddFlightData> flightData = (from m in _Db.flightDataset
                                                   where m.FlightNumber == datas.Flight_Number
                                            orderby m.FlightNumber
                                            select m).ToList();
            data.flightDatas = flightData;
            //var movies = from m in _Db.Movie
            //             select m;
            
            //if (!string.IsNullOrEmpty(searchString))
            //{
            //    movies = movies.Where(s => s.Title.Contains(searchString));
            //}

            //if (!string.IsNullOrEmpty(flightNumber))
            //{
            //    movies = movies.Where(x => x.Genre == flightNumber);
            //}

            //var flightNumberVM = new Flight_NumberViewModel
            //{
            //    Genres = new SelectList(await genreQuery.Distinct().ToListAsync()),
            //    Movies = await movies.ToListAsync()
            //};

            return View(data);
        }
    }
}