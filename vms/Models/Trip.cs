using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace vms.Models
{
    public class Trip
    {
        public int TripID { get; set; }

        [Required]
        [DisplayName("Destination")]
        public string Destination { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime TripDate { get; set; }

        [Required]
        [DisplayName("Trip Fare")]
        public decimal TripFare { get; set; }

        [Required]
        [DisplayName("Fuel Cost")]
        public decimal FuelCost { get; set; }

      
        [DisplayName("Other Expenses")]
        public decimal? OtherExpenses { get; set; }

      
        [DisplayName("Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }


        public static decimal CalculateNetIncome(decimal tripFare, decimal fuelCost, decimal otherExpense)
        {
            decimal NetIncome = tripFare - (fuelCost + otherExpense);
            return NetIncome;
        }



    }
}