using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateRentalAdmin.Data.DbContext;
using RealEstateRentalAdmin.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateRentalAdmin.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationApiController : ControllerBase
    {
        public readonly IDbHelper _dbHelper;
        public LocationApiController(IDbHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        [HttpGet]
        [Route("PerRegion")]

        public IActionResult GetLocationByRegionUuid(Guid regionUuid)
        {
            //var locations = _dbHelper.GetAllLocations();
            //var locationsPerRegion = locations.Where(l => l.RegionUuid == regionUuid).ToList();
            //datasource
            var location = _dbHelper.GetLocationByRegionUuid(regionUuid);



            return Ok(location);
        }

    }
}
