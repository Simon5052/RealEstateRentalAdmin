using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateRentalAdmin.Models.ConfigModels
{
    public class AppSettings
    {
        public string UploadDirectory { get; set; }
        public DbSchemas DbSchemas { get; set; }

    }
}
