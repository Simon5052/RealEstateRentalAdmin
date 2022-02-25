using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateRentalAdmin.Data.DbContext;
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
        public readonly DbHelper _dbHelper;
        public LocationApiController(DbHelper dbHelper)
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
