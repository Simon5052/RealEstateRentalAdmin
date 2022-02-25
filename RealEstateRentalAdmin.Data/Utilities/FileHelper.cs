using System;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace RealEstateRentalAdmin.Data.Utilities
{
    public static class FileHelper
    {

        public static string GetMimeType(string base64String)
        {
            var data = base64String.Substring(0, 5);

            switch (data.ToUpper())
            {
                case "IVBOR":
                    return "image/png";
                case "/9J/4":
                    return "image/jpeg";
                case "AAAAF":
                    return "video/mp4";
                case "JVBER":
                    return "application/pdf";
                case "AAABA":
                    return "image/x-icon";
                case "UMFYI":
                    return "application/x-rar-compressed";
                case "E1XYD":
                    return "text/rtf";
                case "U1PKC":
                    return "text/plain";
                case "MQOWM":
                case "77U/M":
                    return "text/srt";
                default:
                    return string.Empty;
            }
        }

        public static string ConvertToBase64(IFormFile formFile)
        {

            if (formFile != null)
            {
                using (var ms = new MemoryStream())
                {
                    formFile.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    return Convert.ToBase64String(fileBytes);
                }
            }

            return string.Empty;

        }

        public static bool IsImageFile(IFormFile formFile)
        {
            string base64 = ConvertToBase64(formFile);

            if (!string.IsNullOrEmpty(base64))
            {
                var mimeType = GetMimeType(base64);

                if (mimeType == "image/png" || mimeType == "image/jpeg")
                {
                    return true;
                }
            }

            return false;
        }

       

    }
}
