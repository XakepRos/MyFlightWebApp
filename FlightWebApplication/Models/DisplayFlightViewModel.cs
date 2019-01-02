using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Web.Mvc;

namespace FlightWebApplication.Models
{
    public class DisplayFlightViewModel
    {
        [Key]
        [DisplayName("ID")]
        public int ID { get; set; }

        [Required]
        [Range(1000, 2000)]
        [DisplayName("Flight Number")]
        public int FlightNumber { get; set; }

        [StringLength(60, MinimumLength = 3)]
        //[RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [DisplayName("Flight Destination Name")]
        public string DestinationName { get; set; }

        [Required]
        [DisplayName("Flight Distance")]
        public int FlightDistance { get; set; }

        [Required]
        [Range(9, 999)]
        [DisplayName("Flight Price")]
        public decimal FlightPrice { get; set; }

        [Required]
        [Range(1, 100)]
        [DisplayName("Flight Discount Percentage")]
        public int DiscountPercentage { get; set; }

        [DisplayName("Flight Discount Amount")]
        public decimal DiscountedAmount { get; set; }

        [DisplayName("Total Flight Price")]
        public decimal TotalAmount { get; set; }

        public string Delete_Flag { get; set; }
    }
}
