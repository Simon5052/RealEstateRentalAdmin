using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RealEstateRentalAdmin.Data.DbContext;
using RealEstateRentalAdmin.Data.Utilities;
using RealEstateRentalAdmin.Models.ConfigModels;
using RealEstateRentalAdmin.Models.InputModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RealEstateRentalAdmin.Controllers
{
    public class PropertyController : Controller
    {
        public readonly DbHelper _dbHelper;
        private readonly AppSettings _appSettings;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public PropertyController(DbHelper dbHelper, IWebHostEnvironment webHostEnvironment,IOptions<AppSettings> options)
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
        public IActionResult Add(AddPropertyModel addProperty)
        {
            if (addProperty.Picture == null)
            {
                return Content("File(s) not selected");
            }
           

            string imageUrl = UploadBanner(addProperty.Picture);

            var dbResponse = _dbHelper.InsertProperty(addProperty.PropertyName, addProperty.PropertyTypeId, addProperty.LocationId,
                addProperty.Space, addProperty.Rooms, addProperty.Cost, imageUrl);

            if (dbResponse == string.Empty)
                return RedirectToAction(nameof(All));

            return View(addProperty);



        }

        private  string UploadBanner(IFormFile formFile)
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
        public IActionResult Property_Read([DataSourceRequest] DataSourceRequest request)
        {
            var data = _dbHelper.GetAllProperties();

            data = data.OrderByDescending(d => d.CreatedAt).ToList();

            return Json(data.ToDataSourceResult(request));
        }



    }
}

