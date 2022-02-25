using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateRentalAdmin.Models.DbModels
{
    public class AgentModel
    {
        //[HiddenInput(DisplayValue =false)]
        public Guid AgentUuid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
