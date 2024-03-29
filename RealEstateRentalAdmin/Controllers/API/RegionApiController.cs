﻿using Microsoft.AspNetCore.Http;
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
    public class RegionApiController : ControllerBase
    {
        private readonly IDbHelper _dbHelper;
        public RegionApiController(IDbHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        [HttpGet]
        [Route("GetAllRegions")]

        public IActionResult GetAllRegions()
        {
            var regions = _dbHelper.GetAllRegions();
            return Ok(regions);
        }
    }
}
