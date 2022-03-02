using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RealEstateRentalAdmin.Data.DbContext;
using RealEstateRentalAdmin.Data.Utilities;
using RealEstateRentalAdmin.Models.ConfigModels;
using RealEstateRentalAdmin.Models.DbModels;
using RealEstateRentalAdmin.Models.InputModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateRentalAdmin.Controllers
{
    public class AgentController : Controller
    {
         public readonly DbHelper _dbHelper;
        private readonly AppSettings _appSettings;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AgentController(DbHelper dbHelper, IWebHostEnvironment webHostEnvironment, IOptions<AppSettings> options)
        {
            _dbHelper = dbHelper;
            _webHostEnvironment = webHostEnvironment;
            _appSettings = options.Value;
        }
        public IActionResult All()
        {
            
            return View();
        }
        public IActionResult Add()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Add(AddAgentModel addAgent)
        {
            if (addAgent.Picture == null)
            {
                return Content("File(s) not selected");
            }


            string imageUrl = UploadBanner(addAgent.Picture);

            var dbResponse = _dbHelper.InsertAgent(addAgent.FirstName, addAgent.LastName, addAgent.CompanyName,
                addAgent.Email,addAgent.PhoneNumber, imageUrl);

            if (dbResponse == string.Empty)
                return RedirectToAction(nameof(All));

            return View();

        }

        private string UploadBanner(IFormFile formFile)
        {
            try
            {
                string uniqueFileName = null;
                if (!FileHelper.IsImageFile(formFile))
                {
                    return null;
                }
                if (formFile.FileName != null)
                {
                    string uploadsFolder = _appSettings.UploadDirectory;
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }
                    uniqueFileName = Guid.NewGuid() + "_" + formFile.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        formFile.CopyTo(fileStream);
                    }
                }
                return uniqueFileName;
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex);
                return string.Empty;
            }
        }


        [HttpPost]
        public IActionResult Agent_Read([DataSourceRequest] DataSourceRequest request)
        {
            var data = _dbHelper.GetAllAgents();

            //data = data.OrderByDescending(d => d.LastName).ToList();

            return Json(data.ToDataSourceResult(request));
        }

        [HttpPost]
        public IActionResult Agent_Add([DataSourceRequest] DataSourceRequest request, AddAgentModel model)
        {
            if (string.IsNullOrWhiteSpace(model.FirstName) || model.FirstName.Length < 2)
                return BadRequest("CPG First Name should have a minimum of 2 characters");




            var dbResponse = _dbHelper.InsertAgent(model.FirstName, model.LastName, model.CompanyName, model.Email, model.PhoneNumber, model.AgentImage);



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

