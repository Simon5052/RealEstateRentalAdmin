using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateRentalAdmin.Models.InputModels
{
    public class AddAgentModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        
    }
}
