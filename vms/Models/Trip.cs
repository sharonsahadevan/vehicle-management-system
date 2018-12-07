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
        public decimal OtherExpenses { get; set; }

      
        [DisplayName("Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        
        public decimal NetIncome { get; set; }


        

        public static decimal CalculateNetIncome(decimal tripFare, decimal fuelCost, decimal otherExpense)
        {
            decimal rideCost = fuelCost + otherExpense;
            decimal NetIncome = tripFare - rideCost;
            return NetIncome;
        }

        public static decimal TotalIncome()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            try
            {
                var TotalIncome = db.Database.SqlQuery<decimal>("[dbo].[usp_get_totalIncome]").FirstOrDefault();
                return TotalIncome;
            }
            catch (Exception e)
            {
                
            }

            return 0;
        }

        public static decimal FuelExpense()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            try
            {
                var fuelExpense = db.Database.SqlQuery<decimal>("[dbo].[usp_get_fuelExpense]").FirstOrDefault();
                return fuelExpense;
            }

            catch (Exception e)
            {

            }

            return 0;
        }

        public static decimal OtherExpense()
        {
            ApplicationDbContext db = new ApplicationDbContext();

            try
            {
                var otherExpense = db.Database.SqlQuery<decimal>("[dbo].[usp_get_otherExpense]").FirstOrDefault();
                return otherExpense;
            }
            catch (Exception e)
            {

            }

            return 0;
            
        }




    }
}