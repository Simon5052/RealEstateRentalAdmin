using RealEstateRentalAdmin.Data.Interface;
using RealEstateRentalAdmin.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateRentalAdmin.Data.DbContext
{
    public class MockDbHelper : IDbHelper
    {
        public List<MeetingModel> CompletedMeeting()
        {
            throw new NotImplementedException();
        }

        public string DeleteAgent(Guid agentUuid)
        {
            throw new NotImplementedException();
        }

        public string DeleteProperty(Guid propertyUuid)
        {
            throw new NotImplementedException();
        }

        public List<AgentModel> GetAllAgents()
        {
            throw new NotImplementedException();
        }

        public List<GalleryTypeModel> GetAllGalleryType()
        {
            throw new NotImplementedException();
        }

        public List<LocationModel> GetAllLocation()
        {
            throw new NotImplementedException();
        }

        public List<PropertyModel> GetAllProperties()
        {
            throw new NotImplementedException();
        }

        public List<PropertyTypeModel> GetAllPropertyTypes()
        {
            throw new NotImplementedException();
        }

        public List<RegionModel> GetAllRegions()
        {
            throw new NotImplementedException();
        }

        public List<LocationModel> GetLocationByRegionUuid(Guid regionUuid)
        {
            throw new NotImplementedException();
        }

        public List<MeetingModel> GetPendingMeeting()
        {
            throw new NotImplementedException();
        }

        public PropertyModel GetPropertyByUuid(Guid propertyUuid)
        {
            throw new NotImplementedException();
        }

        public string InsertAgent(string firstName, string lastName, string companyName, string email, string phoneNumber, string agentImage)
        {
            throw new NotImplementedException();
        }

        public string InsertGallery(int galleryTypeId, string galleryFileName, int propertyId)
        {
            throw new NotImplementedException();
        }

        public string InsertProperty(string propertyName, Guid propertyTypeUuid, Guid locationUuid, int space, int rooms, double cost, string propertyMainImage)
        {
            throw new NotImplementedException();
        }

        public string MeetingCompleted(Guid meetingUuid, string completedBy, DateTime dateCompleted)
        {
            throw new NotImplementedException();
        }

        public SummaryModel SummaryData()
        {

            return new SummaryModel();
               
        }

        public string UpdateAgent(Guid agentUuid, string firstName, string lastName, string companyName, string email, string phoneNumber)
        {
            throw new NotImplementedException();
        }

        public string UpdateAgentInMeeting(string agentApproved, Guid meetingUuid)
        {
            throw new NotImplementedException();
        }

        public string UpdateProperty(Guid propertyUuid, string propertyName, Guid propertyTypeUuid, Guid locationUuid, int space, int rooms, double cost)
        {
            throw new NotImplementedException();
        }
    }
}
