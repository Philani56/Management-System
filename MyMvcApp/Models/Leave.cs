using System;
using System.ComponentModel.DataAnnotations;

namespace MyMvcApp.Models
{
    public class Leave
    {
        [Key]
        public int LeaveId { get; set; } // Unique identifier for the leave request
        public string EmployeeName { get; set; } // Reason for the leave request

        public DateTime StartDate { get; set; } // Start date of the leave

        public DateTime EndDate { get; set; } // End date of the leave

        public string LeaveType { get; set; } // Type of leave (e.g., sick leave, vacation, maternity/paternity leave)

        public string Reason { get; set; } // Reason for the leave request

        public string Status { get; set; } // Status of the leave request (e.g., Pending, Approved, Rejected)

        public DateTime RequestDate { get; set; } // Date when the leave was requested

        public string ApprovedBy { get; set; } // Name or ID of the person who approved/rejected the leave

        public string Comments { get; set; } // Additional comments or notes
    }
}