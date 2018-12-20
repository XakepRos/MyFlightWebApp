using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlightWebApplication.Models
{
    public class AddFlightData
    {
        [Key]
        [DisplayName("ID")]
        public int ID { get; set; }

        [Required]       
        [DisplayName("Flight Number")]       
        public int FlightNumber { get; set; }     

        //[RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [StringLength(60, MinimumLength = 3)]
        [DisplayName("Flight Destination Name")]
        public string DestinationName { get; set; }
           
        [Required]
        [DisplayName("Flight Distance")]
        public int FlightDistance { get; set; }
        
        [Required]
        [DisplayName("Flight Price")]
        public int FlightPrice { get; set; }

        [Required]
        [DisplayName("Flight Discount Percentage")]
        public int DiscountPercentage{ get; set; }
    }
}