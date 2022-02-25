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
    public class GalleryTypeApiController : ControllerBase
    {
        public readonly DbHelper _dbHelper;
        public GalleryTypeApiController(DbHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        [HttpGet]
        [Route("AllGalleryType")]
        public IActionResult GetAllGalleryType()
        {
            var galleryType = _dbHelper.GetAllGalleryType();
            return Ok(galleryType);
        }
    }
}
