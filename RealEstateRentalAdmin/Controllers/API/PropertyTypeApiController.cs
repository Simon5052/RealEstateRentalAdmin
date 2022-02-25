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
    public class PropertyTypeApiController : ControllerBase
    {
        public readonly DbHelper _dbHelper;
        public PropertyTypeApiController(DbHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        [HttpGet]
        [Route("AllPropertyType")]
        public IActionResult GetAllPropertyType()
        {
            var regions = _dbHelper.GetAllPropertyTypes();
            return Ok(regions);
        }

    }
}
