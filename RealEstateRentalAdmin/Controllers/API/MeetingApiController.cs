using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateRentalAdmin.Data.DbContext;
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
        private readonly DbHelper _dbHelper;

        public MeetingApiController(DbHelper dbHelper)
        {
            _dbHelper = dbHelper;

        }


        [HttpPost]
        [Route("MeetingCompleted")]

        public IActionResult MeetingCompleted(Guid meetingUuid)
        {
            var dbResponse = _dbHelper.MeetingCompleted(meetingUuid);

            if (dbResponse == "Deleted")
            {
                return Ok("Successful");
            }
            return BadRequest("error");
        }
    }
}
