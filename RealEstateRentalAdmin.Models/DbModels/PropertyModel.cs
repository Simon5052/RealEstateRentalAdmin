using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateRentalAdmin.Models.DbModels
{
    public class PropertyModel
    {
        public int PropertyId { get; set; }
        public Guid PropertyUuid { get; set; }
        public string PropertyName { get; set; }
        public int PropertyTypeId { get; set; }
        public Guid PropertyTypeUuid { get; set; }
        public Guid LocationUuid { get; set; }
        public Guid RegionUuid { get; set; }
        public int LocationId { get; set; }
        public int RegionId { get; set; }
        public int Space { get; set; }
        public int Rooms { get; set; }
        public double Cost { get; set; }
        public DateTime CreatedAt { get; set; }
        public string RegionName { get; set; }
        public string Address { get; set; }
        public string PropertyTypeName { get; set; }
        public string PropertyMainImage { get; set; }
        public IFormFile Picture { get; set; }


    }
}
