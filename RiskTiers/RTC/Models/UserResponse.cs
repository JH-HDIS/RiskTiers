using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RTC.Controllers; // Ensure this is correct

namespace RTC.Models
{
    public class UserResponse
    {
        public int Id { get; set; }

        [Required]
        public DateTime RTCCompletionDate { get; set; }

        [Required]
        public string? IRBApplicationNumber { get; set; }

        [Required]
        public string? PIFirstName { get; set; }

        [Required]
        public string? PILastName { get; set; }

        [Required]
        public string? PIJHED { get; set; }

        [Required]
        public string? PIEmailAddress { get; set; }

        public string? StudyContactFirstName { get; set; }

        public string? StudyContactLastName { get; set; }

        public string? StudyContactJHED { get; set; }

        public string? StudyContactEmailAddress { get; set; }

        [Required]
        public bool? InvolvesSensitiveHealthInfo { get; set; }

        [Required]
        public int? NumberOfPeopleOrRecords { get; set; }

        [Required]
        public int? HumanDataSharingLevel { get; set; }

        [Required]
        public bool? AllActivitiesCoveredByConsent { get; set; }

        // Add back the property for DataClassifications
        public List<DataClassification> DataClassifications { get; set; } = new List<DataClassification>();
    }
}
