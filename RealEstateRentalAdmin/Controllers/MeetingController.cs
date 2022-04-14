using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using RealEstateRentalAdmin.Data.DbContext;
using RealEstateRentalAdmin.Data.Interface;
using RealEstateRentalAdmin.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateRentalAdmin.Controllers
{
    public class MeetingController : Controller
    {
        public readonly IDbHelper _dbHelper;
        public MeetingController(IDbHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public IActionResult All()
        {
            //ViewBag.PendingMeeting = _dbHelper.GetPendingMeeting();
            //ViewBag.CompletedMeeting = _dbHelper.CompletedMeeting();
            return View();
        }

        [HttpPost]
        public IActionResult Pending_Read([DataSourceRequest] DataSourceRequest request)
        {
            var data = _dbHelper.GetPendingMeeting();

            data = data.OrderByDescending(d => d.MeetingDate).ToList();

            return Json(data.ToDataSourceResult(request));
        }

        [HttpPost]
        public IActionResult CompletedMeeting_Read([DataSourceRequest] DataSourceRequest request)
        {
            var data = _dbHelper.CompletedMeeting();

            data = data.OrderByDescending(d => d.MeetingDate).ToList();

            return Json(data.ToDataSourceResult(request));
        }

        //[HttpPost]
        //public IActionResult Meeting_Delete([DataSourceRequest] DataSourceRequest request, MeetingModel model)
        //{






        //    var dbResponse = _dbHelper.MeetingCompleted(model.MeetingUuid);



        //    return Json(new[] { model }.ToDataSourceResult(request, ModelState));



        //}

        [HttpPost]
        public IActionResult PendingMeeting_Update([DataSourceRequest] DataSourceRequest request, MeetingModel model)
        {
           



            var dbResponse = _dbHelper.UpdateAgentInMeeting(model.CompletedBy, model.MeetingUuid);



            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
            



        }
    }
}
