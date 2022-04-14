using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RealEstateRentalAdmin.Data.DbContext;
using RealEstateRentalAdmin.Data.Interface;
using RealEstateRentalAdmin.Data.Utilities;
using RealEstateRentalAdmin.Models.ConfigModels;
using RealEstateRentalAdmin.Models.DbModels;
using RealEstateRentalAdmin.Models.InputModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RealEstateRentalAdmin.Controllers
{
    public class PropertyController : Controller
    {
        public readonly IDbHelper _dbHelper;
        private readonly AppSettings _appSettings;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public PropertyController(IDbHelper dbHelper, IWebHostEnvironment webHostEnvironment,IOptions<AppSettings> options)
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
        public IActionResult Add(UpdatePropertyModel addProperty)
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

        //[HttpPost]
        //public IActionResult Property_Update([DataSourceRequest] DataSourceRequest request, PropertyModel model)
        //{
        //    if (string.IsNullOrWhiteSpace(model.PropertyName) || model.PropertyName.Length < 2)
        //        return BadRequest("The Property Wasnt Not Updated");




        //    var dbResponse = _dbHelper.UpdateProperty(model.PropertyUuid, model.PropertyName, model.Space, model.Rooms, model.Cost);



        //    if (dbResponse == "Updated")
        //        return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        //    else
        //        return BadRequest("Oops! An error occurred while Updating Property. Please retry.");



        //}

        [HttpGet]
        public IActionResult AllPropertyType()
        {
            var dbResponce = _dbHelper.GetAllPropertyTypes();
            return Ok(dbResponce);
        }

        [HttpGet]
        public IActionResult AllLocation()
        {
            var dbResponce = _dbHelper.GetAllLocation();
            return Ok(dbResponce);
        }

        [HttpPost]
        public IActionResult Property_Delete([DataSourceRequest] DataSourceRequest request, PropertyModel model)
        {






            var dbResponse = _dbHelper.DeleteProperty(model.PropertyUuid);



            return Json(new[] { model }.ToDataSourceResult(request, ModelState));



        }

        public IActionResult Edit(Guid propertyUuid)
        {
            var property = _dbHelper.GetPropertyByUuid(propertyUuid);
            //property.PropertyTypeUuid = new Guid ("91283cff-8c4b-4802-92db-84ab08f50fa8");
            return View(property);
        }

        [HttpPost]
        public IActionResult Edit(PropertyModel editProperty)
        {
            //if (editProperty.Picture == null)
            //{
            //    return Content("File(s) not selected");
            //}


            //string imageUrl = UploadBanner(editProperty.Picture);

            var dbResponse = _dbHelper.UpdateProperty(editProperty.PropertyUuid, editProperty.PropertyName, editProperty.PropertyTypeUuid,
                editProperty.LocationUuid, editProperty.Space, editProperty.Rooms, editProperty.Cost);

            if (dbResponse == string.Empty)
                return RedirectToAction(nameof(All));

            return View(editProperty);
        }




    }
}

