using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateRentalAdmin.Data.DbContext;
using RealEstateRentalAdmin.Data.Interface;
using RealEstateRentalAdmin.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateRentalAdmin.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingApiController : ControllerBase
    {
        private readonly IDbHelper _dbHelper;

        public MeetingApiController(IDbHelper dbHelper)
        {
            _dbHelper = dbHelper;

        }


        [HttpPost]
        [Route("MeetingCompleted")]

        public IActionResult MeetingCompleted(Guid meetingUuid)
        {
            var userName = "Kofi";
            var dateCompleted = DateTime.Now;
            var dbResponse = _dbHelper.MeetingCompleted(meetingUuid, userName, dateCompleted);

            if (dbResponse == "")
            {
                return Ok(new { dbResponse});
            }
            return BadRequest("error");
        }
    }
}
