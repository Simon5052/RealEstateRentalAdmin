using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateRentalAdmin.Models.DbModels
{
    public class GalleryTypeModel
    {
        public int GalleryTypeId { get; set; }
        public Guid GalleryTypeUuid { get; set; }
        public string Name { get; set; }

    }
}
