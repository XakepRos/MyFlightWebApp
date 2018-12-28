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
        public ActionResult search()
        {
            SearchFlightData searchflighData = new SearchFlightData();
            return View(searchflighData);
        }

        ApplicationDbContext _Db = new ApplicationDbContext();

        // GET: Search
        [HttpPost]
        public ActionResult search(SearchFlightData datas)
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


        //the first parameter is the option that we choose and the second parameter will use the textbox value  
        //public ActionResult Index(string option, string search)
        //{

        //    //if a user choose the radio button option as Subject  
        //    if (option == "Subjects")
        //    {
        //        //Index action method will return a view with a student records based on what a user specify the value in textbox  
        //        return View(db.Students.Where(x = > x.Subjects == search || search == null).ToList());
        //    }
        //    else if (option == "Gender")
        //    {
        //        return View(db.Students.Where(x = > x.Gender == search || search == null).ToList());
        //    }
        //    else
        //    {
        //        return View(db.Students.Where(x = > x.Name.StartsWith(search) || search == null).ToList());
        //    }
        //}



        //public ActionResult Search(string Name, string Surname)
        //{
        //    var SearchList = from m in _db.Klienci
        //                     select m;
        //    if (!String.IsNullOrEmpty(Name))
        //    {
        //        SearchList = SearchList.Where(s => s.Name.Contains(Name));
        //    }
        //    if (!String.IsNullOrEmpty(Surname))
        //    {
        //        SearchList = SearchList.Where(s => s.Nazwisko.Contains(Surname));
        //    }
        //    return View(SearchList);
        //}
    }
}