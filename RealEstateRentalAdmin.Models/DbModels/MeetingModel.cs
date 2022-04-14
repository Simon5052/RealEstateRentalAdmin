using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateRentalAdmin.Models.DbModels
{
    public class MeetingModel
    {
        public int MeetingId { get; set; }
        public Guid MeetingUuid { get; set; }
        public string PropertyName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string CompletedBy { get; set; }
        public DateTime MeetingDate { get; set; }
        public DateTime MeetingScheduled { get; set; }
        public DateTime DateCompleted { get; set; }
        public Boolean MeetUpCompleted { get; set; }
    }
}
