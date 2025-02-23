using System;
using System.ComponentModel.DataAnnotations;

namespace MyMvcApp.Models
{
    public class Employee
    {
        // Personal Information
        [Key]
        [Required]
        public string EmployeeID { get; set; } // Unique Identifier

        [Required, Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Required, Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required, Display(Name = "Date of Birth"), DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required, Display(Name = "Gender")]
        public string Gender { get; set; }

        [Required, Display(Name = "Nationality")]
        public string Nationality { get; set; }

        [Display(Name = "Marital Status")]
        public string MaritalStatus { get; set; }

        // Contact Details
        [Required, Display(Name = "Phone Number"), DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required, Display(Name = "Email Address"), DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [Required, Display(Name = "Residential Address")]
        public string ResidentialAddress { get; set; }

        [Display(Name = "Emergency Contact Name")]
        public string EmergencyContactName { get; set; }

        [Display(Name = "Emergency Contact Relationship")]
        public string EmergencyContactRelationship { get; set; }

        [Display(Name = "Emergency Contact Phone"), DataType(DataType.PhoneNumber)]
        public string EmergencyContactPhone { get; set; }

        // Employment Details
        [Required, Display(Name = "Job Title")]
        public string JobTitle { get; set; }

        [Required, Display(Name = "Department")]
        public string Department { get; set; }

        [Required, Display(Name = "Employment Type")]
        public string EmploymentType { get; set; } // Full-time, Part-time, Contract, Internship

        [Required, Display(Name = "Date of Hire"), DataType(DataType.Date)]
        public DateTime DateOfHire { get; set; }

        [Display(Name = "Work Location")]
        public string WorkLocation { get; set; }               // Office, Remote, Hybrid

        [Display(Name = "Supervisor Name")]
        public string SupervisorName { get; set; }

        [Display(Name = "Probation Period (if applicable)")]
        public string ProbationPeriod { get; set; }
    }
}
