using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vms.Models;

namespace vms.Controllers
{
    public class ReportsController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Reports
        public ActionResult Index()
        {
            //return View();
            return View("~/Views/Reports/Index.cshtml");
        }

        [HttpPost]
        [Authorize]
        public ActionResult GetReportByDate(Trip trip)
        {

            var FromDate = Convert.ToDateTime(trip.TripDate);
            var ToDate = Convert.ToDateTime(trip.TripDate);

            var trips = db.Trips.Where(c => c.TripDate >= FromDate && c.TripDate <= ToDate).ToList();
            return View("~/Views/Reports/TripsDate.cshtml", trips);
        }



        [HttpPost]
        [Authorize]
        public ActionResult GetReportByDestination(Trip trip)
        {

            var destination = trip.Destination;
            

            var trips = db.Trips.Where(c => c.Destination == destination);
            return View("~/Views/Reports/TripsDestination.cshtml", trips);
        }



    }
}
       
    
