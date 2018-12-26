using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlightWebApplication.Models
{
    public class SearchFlightData
    {
        public List<AddFlightData> flightDatas;
        
        public int Flight_Number { get; set; }
        public string Destination_Name { get; set; }
        public string LowestFlightPrice { get; set; }
        public string SearchString { get; set; }
    }
}