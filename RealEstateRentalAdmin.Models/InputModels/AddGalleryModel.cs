using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateRentalAdmin.Models.InputModels
{
    public class AddGalleryModel
    {
        public int GalleryTypeId { get; set; }
        public IFormFile GalleryFileName { get; set; }
        public string PropertyId { get; set; }

    }
}
