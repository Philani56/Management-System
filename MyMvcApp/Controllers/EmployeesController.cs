using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyMvcApp.Models;

using ClosedXML.Excel;
using System.IO;

namespace MyMvcApp.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            return View(await _context.Employees.ToListAsync());
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .FirstOrDefaultAsync(m => m.EmployeeID == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeID,FirstName,MiddleName,LastName,DateOfBirth,Gender,Nationality,MaritalStatus,PhoneNumber,EmailAddress,ResidentialAddress,EmergencyContactName,EmergencyContactRelationship,EmergencyContactPhone,JobTitle,Department,EmploymentType,DateOfHire,WorkLocation,SupervisorName,ProbationPeriod")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Edit(string id, [Bind("EmployeeID,FirstName,MiddleName,LastName,DateOfBirth,Gender,Nationality,MaritalStatus,PhoneNumber,EmailAddress,ResidentialAddress,EmergencyContactName,EmergencyContactRelationship,EmergencyContactPhone,JobTitle,Department,EmploymentType,DateOfHire,WorkLocation,SupervisorName,ProbationPeriod")] Employee employee)
        {
            if (id != employee.EmployeeID)
            {
                return Json(new { success = false, message = "Employee not found." });
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();

                    // Return success response
                    return Json(new { success = true, message = "Employee details saved successfully!" });
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.EmployeeID))
                    {
                        return Json(new { success = false, message = "Employee not found." });
                    }
                    else
                    {
                        return Json(new { success = false, message = "An error occurred while saving the employee details." });
                    }
                }
            }

            // If the model state is invalid, return validation errors
            var errors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();

            return Json(new { success = false, message = "Please correct the errors and try again.", errors });
        }

        private bool EmployeeExists(string id)
        {
            return _context.Employees.Any(e => e.EmployeeID == id);
        }
        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .FirstOrDefaultAsync(m => m.EmployeeID == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

public IActionResult ExportToExcel()
    {
        var employees = _context.Employees.ToList(); // Fetch all employees

        using (var workbook = new XLWorkbook())
        {
            var worksheet = workbook.Worksheets.Add("Employees");
            var currentRow = 1;

            // Add headers
            worksheet.Cell(currentRow, 1).Value = "EmployeeID";
            worksheet.Cell(currentRow, 2).Value = "FirstName";
            worksheet.Cell(currentRow, 3).Value = "MiddleName";
            worksheet.Cell(currentRow, 4).Value = "LastName";
            worksheet.Cell(currentRow, 5).Value = "DateOfBirth";
            worksheet.Cell(currentRow, 6).Value = "Gender";
            worksheet.Cell(currentRow, 7).Value = "Nationality";
            worksheet.Cell(currentRow, 8).Value = "MaritalStatus";
            worksheet.Cell(currentRow, 9).Value = "PhoneNumber";
            worksheet.Cell(currentRow, 10).Value = "EmailAddress";
            worksheet.Cell(currentRow, 11).Value = "ResidentialAddress";
            worksheet.Cell(currentRow, 12).Value = "EmergencyContactName";
            worksheet.Cell(currentRow, 13).Value = "EmergencyContactRelationship";
            worksheet.Cell(currentRow, 14).Value = "EmergencyContactPhone";
            worksheet.Cell(currentRow, 15).Value = "JobTitle";
            worksheet.Cell(currentRow, 16).Value = "Department";
            worksheet.Cell(currentRow, 17).Value = "EmploymentType";
            worksheet.Cell(currentRow, 18).Value = "DateOfHire";
            worksheet.Cell(currentRow, 19).Value = "WorkLocation";
            worksheet.Cell(currentRow, 20).Value = "SupervisorName";
            worksheet.Cell(currentRow, 21).Value = "ProbationPeriod";

            // Add data
            foreach (var employee in employees)
            {
                currentRow++;
                worksheet.Cell(currentRow, 1).Value = employee.EmployeeID;
                worksheet.Cell(currentRow, 2).Value = employee.FirstName;
                worksheet.Cell(currentRow, 3).Value = employee.MiddleName;
                worksheet.Cell(currentRow, 4).Value = employee.LastName;
                worksheet.Cell(currentRow, 5).Value = employee.DateOfBirth.ToShortDateString();
                worksheet.Cell(currentRow, 6).Value = employee.Gender;
                worksheet.Cell(currentRow, 7).Value = employee.Nationality;
                worksheet.Cell(currentRow, 8).Value = employee.MaritalStatus;
                worksheet.Cell(currentRow, 9).Value = employee.PhoneNumber;
                worksheet.Cell(currentRow, 10).Value = employee.EmailAddress;
                worksheet.Cell(currentRow, 11).Value = employee.ResidentialAddress;
                worksheet.Cell(currentRow, 12).Value = employee.EmergencyContactName;
                worksheet.Cell(currentRow, 13).Value = employee.EmergencyContactRelationship;
                worksheet.Cell(currentRow, 14).Value = employee.EmergencyContactPhone;
                worksheet.Cell(currentRow, 15).Value = employee.JobTitle;
                worksheet.Cell(currentRow, 16).Value = employee.Department;
                worksheet.Cell(currentRow, 17).Value = employee.EmploymentType;
                worksheet.Cell(currentRow, 18).Value = employee.DateOfHire.ToShortDateString();
                worksheet.Cell(currentRow, 19).Value = employee.WorkLocation;
                worksheet.Cell(currentRow, 20).Value = employee.SupervisorName;
                worksheet.Cell(currentRow, 21).Value = employee.ProbationPeriod;
            }

            // Save the workbook to a memory stream
            using (var stream = new MemoryStream())
            {
                workbook.SaveAs(stream);
                var content = stream.ToArray();
                return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Employees.xlsx");
            }
        }
    }
}
}
