using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EA446115_MIS4200.Models
{
    public class Flyer
    {
        public int flyerID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public DateTime flyerSince { get; set; }
        public ICollection<Flight> Flight { get; set; }
    }

    public class Flight
    {
        public int flightID { get; set; }
        public string description { get; set; }
        public DateTime flightDate { get; set; }
        public ICollection<FlightDetail> FlightDetail { get; set; }
        public int flyerID { get; set; }
        public virtual Flyer Flyer { get; set; }
        public int airlineID { get; set; }

    }

    public class Airplane
    {
        
        public int airplaneID { get; set; }
        public string Description { get; set; }
        public ICollection<FlightDetail> FlightDetail { get; set; }
    }

    public class FlightDetail
    {
        [Key]
        public int flightdetailID { get; set; }
        public decimal price { get; set; }
        public int flightID { get; set; }
        public virtual Flight Flight { get; set; }
        public int airplaneID { get; set; }
        public virtual Airplane Airplane { get; set; }


    }

}