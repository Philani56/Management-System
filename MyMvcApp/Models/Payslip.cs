using System;
using System.ComponentModel.DataAnnotations;

namespace MyMvcApp.Models
{
    public class Payslip
    {
        // Unique identifier for the payslip
        [Key]
        public int PayslipId { get; set; }

        // Employee code or ID
        public string EmployeeCode { get; set; }

        // Employee's full name
        public string EmployeeName { get; set; }

        // Start date of the pay period
        public DateTime PaymentDate { get; set; }

        // Name of the company
        public string CompanyName { get; set; }

        // Employee's salary
        public decimal Salary { get; set; }

        // UIF (Unemployment Insurance Fund) contribution
        public decimal UIF { get; set; }

    }
}