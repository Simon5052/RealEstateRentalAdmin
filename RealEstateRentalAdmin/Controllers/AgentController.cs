using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using RealEstateRentalAdmin.Data.DbContext;
using RealEstateRentalAdmin.Models.DbModels;
using RealEstateRentalAdmin.Models.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateRentalAdmin.Controllers
{
    public class AgentController : Controller
    {
         public readonly DbHelper _dbHelper;

        public AgentController(DbHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public IActionResult All()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Agent_Read([DataSourceRequest] DataSourceRequest request)
        {
            var data = _dbHelper.GetAllAgents();

            //data = data.OrderByDescending(d => d.LastName).ToList();

            return Json(data.ToDataSourceResult(request));
        }

        [HttpPost]
        public IActionResult Agent_Add([DataSourceRequest] DataSourceRequest request, AgentModel model)
        {
            if (string.IsNullOrWhiteSpace(model.FirstName) || model.FirstName.Length < 2)
                return BadRequest("CPG First Name should have a minimum of 2 characters");




            var dbResponse = _dbHelper.InsertAgent(model.FirstName, model.LastName, model.CompanyName, model.Email, model.PhoneNumber);



            if (dbResponse == "Added")
                return Json(new[] { model }.ToDataSourceResult(request, ModelState));
            else
                return BadRequest("Oops! An error occurred while adding Agent. Please retry.");



        }

        [HttpPost]
        public IActionResult Agent_Update([DataSourceRequest] DataSourceRequest request, AgentModel model)
        {
            if (string.IsNullOrWhiteSpace(model.FirstName) || model.FirstName.Length < 2)
                return BadRequest("The Agent Wasnt Not Updated");




            var dbResponse = _dbHelper.UpdateAgent(model.AgentUuid, model.FirstName, model.LastName, model.CompanyName, model.Email, model.PhoneNumber);



            if (dbResponse == "Updated")
                return Json(new[] { model }.ToDataSourceResult(request, ModelState));
            else
                return BadRequest("Oops! An error occurred while Updating Product. Please retry.");



        }

        [HttpPost]
        public IActionResult Agent_Delete([DataSourceRequest] DataSourceRequest request, AgentModel model)
        {

            




            var dbResponse = _dbHelper.DeleteAgent(model.AgentUuid);



             return Json(new[] { model }.ToDataSourceResult(request, ModelState));



        }

    }
    }

