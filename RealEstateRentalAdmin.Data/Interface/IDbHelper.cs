using RealEstateRentalAdmin.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateRentalAdmin.Data.Interface
{
    public interface IDbHelper
    {
        List<MeetingModel> CompletedMeeting();
        string DeleteAgent(Guid agentUuid);
        string DeleteProperty(Guid propertyUuid);
        List<AgentModel> GetAllAgents();
        List<GalleryTypeModel> GetAllGalleryType();
        List<LocationModel> GetAllLocation();
        List<PropertyModel> GetAllProperties();
        List<PropertyTypeModel> GetAllPropertyTypes();
        List<RegionModel> GetAllRegions();
        List<LocationModel> GetLocationByRegionUuid(Guid regionUuid);
        List<MeetingModel> GetPendingMeeting();
        PropertyModel GetPropertyByUuid(Guid propertyUuid);
        string InsertAgent(string firstName, string lastName, string companyName, string email, string phoneNumber, string agentImage);
        string InsertGallery(int galleryTypeId, string galleryFileName, int propertyId);
        string InsertProperty(string propertyName, Guid propertyTypeUuid, Guid locationUuid, int space, int rooms, double cost, string propertyMainImage);
        string MeetingCompleted(Guid meetingUuid, string completedBy, DateTime dateCompleted);
        SummaryModel SummaryData();
        string UpdateAgent(Guid agentUuid, string firstName, string lastName, string companyName, string email, string phoneNumber);
        string UpdateAgentInMeeting(string agentApproved, Guid meetingUuid);
        string UpdateProperty(Guid propertyUuid, string propertyName, Guid propertyTypeUuid, Guid locationUuid, int space, int rooms, double cost);
    }
}
