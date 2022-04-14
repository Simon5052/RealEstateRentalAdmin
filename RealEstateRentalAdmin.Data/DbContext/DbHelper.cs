using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Npgsql;
using RealEstateRentalAdmin.Data.Interface;
using RealEstateRentalAdmin.Data.Utilities;
using RealEstateRentalAdmin.Models.ConfigModels;
using RealEstateRentalAdmin.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace RealEstateRentalAdmin.Data.DbContext
{
    public class DbHelper : IDbHelper
    {
        public readonly Logger _logger;




        public string dbConnString;
        public string dbSchema;


        public DbHelper(Logger logger, IConfiguration configuration, IOptions<AppSettings> options)
        {
            AppSettings appSettings = options.Value;
            _logger = logger;

            dbConnString = configuration.GetConnectionString("RealEstateDb");
            dbSchema = appSettings.DbSchemas.RealEstateDbSchema;



        }


        private string GetConnectionString(IConfiguration configuration)
        {

            string dbCon = dbConnString;
            return dbCon;


        }
        private string GetDbSchema(IConfiguration configuration)
        {
            return dbSchema;
        }

        private NpgsqlConnection CreateConnection()
        {
            try
            {
                return new NpgsqlConnection(dbConnString);
            }
            catch (Exception ex)
            {
                _logger.logError(ex);
                return null;
            }
        }
        private void DisposeConnection(NpgsqlConnection con)
        {
            try
            {
                if (con != null)
                {
                    con.Close();
                    con.Dispose();
                }
            }
            catch
            {
                //Ignore exception
            }
        }
        public SummaryModel SummaryData()
        {
            SummaryModel property = new SummaryModel();
            var dbCon = CreateConnection();
            try
            {
                using (dbCon)
                {
                    dbCon.Open();
                    property = dbCon.QueryFirstOrDefault<SummaryModel>("\"GetSummaryData\"", commandType: CommandType.StoredProcedure);
                }
                DisposeConnection(dbCon);
                return (SummaryModel)property;
            }
            catch (Exception ex)
            {
                DisposeConnection(dbCon);

                _logger.logError(ex);
                return (SummaryModel)property;
            }

        }

        public List<PropertyModel> GetAllProperties()
        {
            List<PropertyModel> allProperties = new List<PropertyModel>();
            var dbCon = CreateConnection();
            try
            {
                using (dbCon)
                {
                    dbCon.Open();
                    allProperties = dbCon.Query<PropertyModel>("\"GetAllProperty\"", commandType: System.Data.CommandType.StoredProcedure).ToList();
                }
                DisposeConnection(dbCon);
                return (List<PropertyModel>)allProperties;
            }
            catch (Exception ex)
            {
                DisposeConnection(dbCon);

                _logger.logError(ex);
                return (List<PropertyModel>)allProperties;
            }

        }

        public string InsertProperty(string propertyName, Guid propertyTypeUuid, Guid locationUuid, int space, int rooms,
           double cost, string propertyMainImage)
        {
            string dbResponse = null;
            var dbCon = CreateConnection();
            try
            {
                using (dbCon)
                {
                    dbCon.Open();
                    dbResponse = dbCon.QueryFirstOrDefault<string>("\"InsertProperty\"", new
                    {
                        _propertyName = propertyName,
                        _propertyTypeUuid = propertyTypeUuid,
                        _locationUuid = locationUuid,
                        _space = space,
                        _rooms = rooms,
                        _cost = cost,
                        _propertyMainImage = propertyMainImage

                    }, commandType: CommandType.StoredProcedure);
                }
                DisposeConnection(dbCon);
                return (string)dbResponse;
            }
            catch (Exception ex)
            {
                DisposeConnection(dbCon);

                _logger.logError(ex);
                return (string)dbResponse;
            }

        }

        public List<RegionModel> GetAllRegions()
        {
            List<RegionModel> allRegions = new List<RegionModel>();
            var dbCon = CreateConnection();
            try
            {
                using (dbCon)
                {
                    dbCon.Open();
                    allRegions = dbCon.Query<RegionModel>("\"GetAllRegion\"", commandType: System.Data.CommandType.StoredProcedure).ToList();
                }
                DisposeConnection(dbCon);
                return (List<RegionModel>)allRegions;
            }
            catch (Exception ex)
            {
                DisposeConnection(dbCon);

                _logger.logError(ex);
                return (List<RegionModel>)allRegions;
            }

        }

        public List<LocationModel> GetLocationByRegionUuid(Guid regionUuid)
        {
            List<LocationModel> location = new List<LocationModel>();
            var dbCon = CreateConnection();
            try
            {
                using (dbCon)
                {
                    dbCon.Open();
                    location = dbCon.Query<LocationModel>("\"GetLocationByRegionUuid\"", new { _regionUuid = regionUuid }, commandType: CommandType.StoredProcedure).ToList();
                }
                DisposeConnection(dbCon);
                return (List<LocationModel>)location;
            }
            catch (Exception ex)
            {
                DisposeConnection(dbCon);

                //_logger.LogError(ex);
                return (List<LocationModel>)location;
            }

        }

        public List<PropertyTypeModel> GetAllPropertyTypes()
        {
            List<PropertyTypeModel> allPropertyTypes = new List<PropertyTypeModel>();
            var dbCon = CreateConnection();
            try
            {
                using (dbCon)
                {
                    dbCon.Open();
                    allPropertyTypes = dbCon.Query<PropertyTypeModel>("\"GetAllPropertyType\"", commandType: System.Data.CommandType.StoredProcedure).ToList();
                }
                DisposeConnection(dbCon);
                return (List<PropertyTypeModel>)allPropertyTypes;
            }
            catch (Exception ex)
            {
                DisposeConnection(dbCon);

                _logger.logError(ex);
                return (List<PropertyTypeModel>)allPropertyTypes;
            }

        }

        public List<AgentModel> GetAllAgents()
        {
            List<AgentModel> allAgent = new List<AgentModel>();
            var dbCon = CreateConnection();
            try
            {
                using (dbCon)
                {
                    dbCon.Open();
                    allAgent = dbCon.Query<AgentModel>("\"GetAllAgent\"", commandType: System.Data.CommandType.StoredProcedure).ToList();
                }
                DisposeConnection(dbCon);
                return (List<AgentModel>)allAgent;
            }
            catch (Exception ex)
            {
                DisposeConnection(dbCon);

                _logger.logError(ex);
                return (List<AgentModel>)allAgent;
            }

        }

        public string InsertAgent(string firstName, string lastName, string companyName, string email,
            string phoneNumber, string agentImage)
        {
            string dbResponse = string.Empty;
            var dbCon = CreateConnection();
            try
            {
                using (dbCon)
                {
                    dbCon.Open();
                    dbResponse = dbCon.QueryFirstOrDefault<string>("\"InsertAgent\"", new
                    {
                        _firstName = firstName,
                        _lastName = lastName,
                        _companyName = companyName,
                        _email = email,
                        _phoneNumber = phoneNumber,
                        _agentImage = agentImage
                    }, commandType: CommandType.StoredProcedure);
                }
                DisposeConnection(dbCon);
                return (string)dbResponse;
            }
            catch (Exception ex)
            {
                DisposeConnection(dbCon);

                _logger.logError(ex);
                return (string)dbResponse;
            }

        }
        public string UpdateAgent(Guid agentUuid, string firstName, string lastName, string companyName, string email,
            string phoneNumber)
        {
            string dbResponse = string.Empty;
            var dbCon = CreateConnection();
            try
            {
                using (dbCon)
                {
                    dbCon.Open();
                    dbResponse = dbCon.QueryFirstOrDefault<string>("\"UpdateAgent\"", new
                    {
                        _agentUuid = agentUuid,
                        _firstName = firstName,
                        _lastName = lastName,
                        _companyName = companyName,
                        _email = email,
                        _phoneNumber = phoneNumber


                    }, commandType: CommandType.StoredProcedure);
                }
                DisposeConnection(dbCon);
                return (string)dbResponse;
            }
            catch (Exception ex)
            {
                DisposeConnection(dbCon);

                _logger.logError(ex);
                return (string)dbResponse;
            }

        }
        public string DeleteAgent(Guid agentUuid)
        {
            string dbResponse = string.Empty;
            var dbCon = CreateConnection();
            try
            {
                using (dbCon)
                {
                    dbCon.Open();
                    dbResponse = dbCon.QueryFirstOrDefault<string>("\"DeleteAgent\"", new
                    {
                        _agentUuid = agentUuid,

                    }, commandType: CommandType.StoredProcedure);
                }
                DisposeConnection(dbCon);
                return (string)dbResponse;
            }
            catch (Exception ex)
            {
                DisposeConnection(dbCon);

                //_logger.LogError(ex);
                return (string)dbResponse;
            }

        }

        public List<GalleryTypeModel> GetAllGalleryType()
        {
            List<GalleryTypeModel> allGallery = new List<GalleryTypeModel>();
            var dbCon = CreateConnection();
            try
            {
                using (dbCon)
                {
                    dbCon.Open();
                    allGallery = dbCon.Query<GalleryTypeModel>("\"GetGalleryType\"", commandType: System.Data.CommandType.StoredProcedure).ToList();
                }
                DisposeConnection(dbCon);
                return (List<GalleryTypeModel>)allGallery;
            }
            catch (Exception ex)
            {
                DisposeConnection(dbCon);

                _logger.logError(ex);
                return (List<GalleryTypeModel>)allGallery;
            }

        }

        public string InsertGallery(int galleryTypeId, string galleryFileName, int propertyId)
        {
            string dbResponse = string.Empty;
            var dbCon = CreateConnection();
            try
            {
                using (dbCon)
                {
                    dbCon.Open();
                    dbResponse = dbCon.QueryFirstOrDefault<string>("\"InsertGallery\"", new
                    {
                        _galleryTypeId = galleryTypeId,
                        _galleryFileName = galleryFileName,
                        _propertyId = propertyId


                    }, commandType: CommandType.StoredProcedure);
                }
                DisposeConnection(dbCon);
                return (string)dbResponse;
            }
            catch (Exception ex)
            {
                DisposeConnection(dbCon);

                _logger.logError(ex);
                return (string)dbResponse;
            }

        }

        public PropertyModel GetPropertyByUuid(Guid propertyUuid)
        {
            PropertyModel property = new PropertyModel();
            var dbCon = CreateConnection();
            try
            {
                using (dbCon)
                {
                    dbCon.Open();
                    property = dbCon.QueryFirstOrDefault<PropertyModel>("\"GetPropertyByUuid\"", new { _propertyUuid = propertyUuid }, commandType: CommandType.StoredProcedure);
                }
                DisposeConnection(dbCon);
                return (PropertyModel)property;
            }
            catch (Exception ex)
            {
                DisposeConnection(dbCon);

                //_logger.LogError(ex);
                return (PropertyModel)property;
            }

        }

        public List<MeetingModel> GetPendingMeeting()
        {
            List<MeetingModel> pendingProperty = new List<MeetingModel>();
            var dbCon = CreateConnection();
            try
            {
                using (dbCon)
                {
                    dbCon.Open();
                    pendingProperty = dbCon.Query<MeetingModel>("\"GetPendingMeeting\"", commandType: System.Data.CommandType.StoredProcedure).ToList();
                }
                DisposeConnection(dbCon);
                return (List<MeetingModel>)pendingProperty;
            }
            catch (Exception ex)
            {
                DisposeConnection(dbCon);

                _logger.logError(ex);
                return (List<MeetingModel>)pendingProperty;
            }
        }

        public List<MeetingModel> CompletedMeeting()
        {
            List<MeetingModel> completedProperty = new List<MeetingModel>();
            var dbCon = CreateConnection();
            try
            {
                using (dbCon)
                {
                    dbCon.Open();
                    completedProperty = dbCon.Query<MeetingModel>("\"CompletedMeeting\"", commandType: System.Data.CommandType.StoredProcedure).ToList();
                }
                DisposeConnection(dbCon);
                return (List<MeetingModel>)completedProperty;
            }
            catch (Exception ex)
            {
                DisposeConnection(dbCon);

                _logger.logError(ex);
                return (List<MeetingModel>)completedProperty;
            }

        }

        public string MeetingCompleted(Guid meetingUuid, string completedBy, DateTime dateCompleted)
        {
            string dbResponse = string.Empty;
            var dbCon = CreateConnection();
            try
            {
                using (dbCon)
                {
                    dbCon.Open();
                    dbResponse = dbCon.QueryFirstOrDefault<string>("\"MeetingCompleted\"", new
                    {
                        _meetingUuid = meetingUuid,
                        _completedBy = completedBy,
                        _dateCompleted = dateCompleted

                    }, commandType: CommandType.StoredProcedure);
                }
                DisposeConnection(dbCon);
                return (string)dbResponse;
            }
            catch (Exception ex)
            {
                DisposeConnection(dbCon);

                _logger.logError(ex);
                return (string)dbResponse;
            }

        }

        public string UpdateAgentInMeeting(string agentApproved, Guid meetingUuid)
        {
            string dbResponse = string.Empty;
            var dbCon = CreateConnection();
            try
            {
                using (dbCon)
                {
                    dbCon.Open();
                    dbResponse = dbCon.QueryFirstOrDefault<string>("\"UpdatePendingMeeting\"", new
                    {
                        _agentApproved = agentApproved,
                        _meetingUuid = meetingUuid



                    }, commandType: CommandType.StoredProcedure);
                }
                DisposeConnection(dbCon);
                return (string)dbResponse;
            }
            catch (Exception ex)
            {
                DisposeConnection(dbCon);

                _logger.logError(ex);
                return (string)dbResponse;
            }

        }

        public string UpdateProperty(Guid propertyUuid, string propertyName, Guid propertyTypeUuid, Guid locationUuid, int space,
            int rooms, double cost)
        {
            string dbResponse = string.Empty;
            var dbCon = CreateConnection();
            try
            {
                using (dbCon)
                {
                    dbCon.Open();
                    dbResponse = dbCon.QueryFirstOrDefault<string>("\"UpdateProperty\"", new
                    {
                        _propertyUuid = propertyUuid,
                        _propertyName = propertyName,
                        _popertyTypeUuid = propertyTypeUuid,
                        _locationUuid = locationUuid,
                        _space = space,
                        _rooms = rooms,
                        _cost = cost,


                    }, commandType: CommandType.StoredProcedure);
                }
                DisposeConnection(dbCon);
                return (string)dbResponse;
            }
            catch (Exception ex)
            {
                DisposeConnection(dbCon);

                _logger.logError(ex);
                return (string)dbResponse;
            }

        }

        public List<LocationModel> GetAllLocation()
        {
            List<LocationModel> allProperties = new List<LocationModel>();
            var dbCon = CreateConnection();
            try
            {
                using (dbCon)
                {
                    dbCon.Open();
                    allProperties = dbCon.Query<LocationModel>("\"GetAllLocation\"", commandType: System.Data.CommandType.StoredProcedure).ToList();
                }
                DisposeConnection(dbCon);
                return (List<LocationModel>)allProperties;
            }
            catch (Exception ex)
            {
                DisposeConnection(dbCon);

                _logger.logError(ex);
                return (List<LocationModel>)allProperties;
            }

        }

        public string DeleteProperty(Guid propertyUuid)
        {
            string dbResponse = string.Empty;
            var dbCon = CreateConnection();
            try
            {
                using (dbCon)
                {
                    dbCon.Open();
                    dbResponse = dbCon.QueryFirstOrDefault<string>("\"DeleteProperty\"", new
                    {
                        _propertyUuid = propertyUuid,

                    }, commandType: CommandType.StoredProcedure);
                }
                DisposeConnection(dbCon);
                return (string)dbResponse;
            }
            catch (Exception ex)
            {
                DisposeConnection(dbCon);

                //_logger.LogError(ex);
                return (string)dbResponse;
            }

        }



    }











    
}
