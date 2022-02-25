using Microsoft.Extensions.Options;
using RealEstateRentalAdmin.Models.ConfigModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RealEstateRentalAdmin.Data.Utilities
{
    public class Logger
    {
        public static bool VerboseLogging { get; set; }
        private static readonly object Locker = new object();
        private string _infoLogDirectory;
        private string _errorLogDirectory;
        private string _warningLogDirectory;

        public Logger()
        {
            var _logDirectories = new LogDirectory
            {
                Error = "./Error_Test",
                Info = "./Info_Test",
                Warning = "./Warning_Test"
            };

            SetDirectories(_logDirectories);
        }

        public Logger(IOptions<LogDirectory> options)
        {
            var _logDirectories = options.Value;
            SetDirectories(_logDirectories);
        }

        private void SetDirectories(LogDirectory directories)
        {
            _errorLogDirectory = directories.Error;
            _infoLogDirectory = directories.Info;
            _warningLogDirectory = directories.Warning;
        }

        public void logError(Exception x)
        {
            try
            {
                var dir = Path.Combine(_errorLogDirectory, DateTime.Now.ToString("yyyy_MM_dd"));
                CheckDir(dir);
                dir = Path.Combine(dir, DateTime.Now.ToString("HH"));
                CheckDir(dir);

                var errorMessage = $"{DateTime.Now.ToString("HH:mm:ss")} || {x.ToString()}  \r\n {x.StackTrace} \n";

                var logFileName = string.Format("RealEstateRentalsAdmin_Error_{0}_{1}.log", DateTime.Now.ToString("yyyy_MM_dd"), DateTime.Now.ToString("HH"));
                var logFilePath = Path.Combine(dir, logFileName);

                using (StreamWriter sw = File.AppendText(logFilePath))
                {
                    sw.WriteLine(errorMessage);
                }
            }
            catch
            {
                // ignored
            }
        }

        public void logError(string message)
        {
            try
            {
                var dir = Path.Combine(_errorLogDirectory, DateTime.Now.ToString("yyyy_MM_dd"));
                CheckDir(dir);
                dir = Path.Combine(dir, DateTime.Now.ToString("HH"));
                CheckDir(dir);

                var errorMessage = $"{DateTime.Now.ToString("HH:mm:ss")} || {message} \n";

                var logFileName = string.Format("RealEstateRentalsAdmin_Error_{0}_{1}.log", DateTime.Now.ToString("yyyy_MM_dd"), DateTime.Now.ToString("HH"));
                var logFilePath = Path.Combine(dir, logFileName);

                using (StreamWriter sw = File.AppendText(logFilePath))
                {
                    sw.WriteLine(errorMessage);
                }
            }
            catch
            {
                // ignored
            }
        }

        public void logInfo(string message)
        {
            try
            {
                var dir = Path.Combine(_infoLogDirectory, DateTime.Now.ToString("yyyy_MM_dd"));
                CheckDir(dir);
                dir = Path.Combine(dir, DateTime.Now.ToString("HH"));
                CheckDir(dir);

                var infoMessage = $"{DateTime.Now.ToString("HH:mm:ss")} || {message}\n";

                var logFileName = string.Format("RealEstateRentalsAdmin_Info_{0}_{1}.log", DateTime.Now.ToString("yyyy_MM_dd"), DateTime.Now.ToString("HH"));
                var logFilePath = Path.Combine(dir, logFileName);

                using (StreamWriter sw = File.AppendText(logFilePath))
                {
                    sw.WriteLine(infoMessage);
                }
            }
            catch
            {
                // ignored
            }
        }

        public void logWarning(string message)
        {
            lock (Locker)
            {
                try
                {
                    var dir = Path.Combine(_warningLogDirectory, DateTime.Now.ToString("yyyy_MM_dd"));
                    CheckDir(dir);
                    dir = Path.Combine(dir, DateTime.Now.ToString("HH"));
                    CheckDir(dir);

                    var warningMessage = $"{DateTime.Now.ToString("HH:mm:ss")} || {message} \n";

                    var logFileName = string.Format("RealEstateRentalsAdmin_Warning_{0}_{1}.log", DateTime.Now.ToString("yyyy_MM_dd"), DateTime.Now.ToString("HH"));
                    var logFilePath = Path.Combine(dir, logFileName);

                    using (StreamWriter sw = File.AppendText(logFilePath))
                    {
                        sw.WriteLine(warningMessage);
                    }
                }
                catch
                {
                    // ignored
                }
            }
        }

        private void CheckDir(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}

