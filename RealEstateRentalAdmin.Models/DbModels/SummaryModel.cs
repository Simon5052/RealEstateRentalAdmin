using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateRentalAdmin.Models.DbModels
{
    public class SummaryModel
    {
        public int Properties { get; set; }
        public int Agents { get; set; }
        public int Rentals { get; set; }
        public int RentalsWithoutAgent { get; set; }
        public int AgentRental { get; set; }
        public double AccruedRentals { get; set; }


    }
}
