using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateRentalAdmin.Models.InputModels
{
    public class UpdatePropertyModel
    {
        public string PropertyName { get; set; }
        public Guid PropertyUuid { get; set; }
        public string PropertyMainImage { get; set; }
        public IFormFile Picture { get; set; }
        public int GalleryTypeId { get; set; }
        public Guid PropertyTypeId { get; set; }
        public Guid RegionId { get; set; }
        public Guid LocationId { get; set; }

        public int Space { get; set; }
        public int Rooms { get; set; }
        public double Cost { get; set; }
        public string PropertyTypeName { get; set; }
    }
}
