using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Options;
using RealEstateRentalAdmin.Models.ConfigModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateRentalAdmin.Controllers
{
    public class DownloadController : Controller
    {
        private readonly AppSettings _appSettings;
        public DownloadController(IOptions<AppSettings> options)
        {
            _appSettings = options.Value;

        }

        public FileResult Image(string fileName)
        {
            try
            {
                var requestFilePath = Path.Combine(_appSettings.UploadDirectory, fileName);



               


                byte[] fileBytes = System.IO.File.ReadAllBytes(requestFilePath);
                //var uploadedFileName = GetFileNameUsedInFileUpload(fileName, "RequestLetter");



                return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
            }
            catch (Exception ex)
            {
                //_logger.logError(ex);
                return null;
            }
        }
    }
}
