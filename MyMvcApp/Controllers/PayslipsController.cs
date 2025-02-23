using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyMvcApp.Models;

using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.IO;

namespace MyMvcApp.Controllers
{
    public class PayslipsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PayslipsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Payslips
        public async Task<IActionResult> Index()
        {
            // By default, return an empty list
            return View(new List<Payslip>());
        }

        // GET: Payslips/Search
        public async Task<IActionResult> Search(string employeeCode)
        {
            if (string.IsNullOrEmpty(employeeCode))
            {
                // If no employee code is provided, return an empty list
                return View(new List<Payslip>());
            }

            // Filter payslips by employee code
            var payslips = await _context.Payslips
                .Where(p => p.EmployeeCode == employeeCode)
                .ToListAsync();

            ViewBag.EmployeeCode = employeeCode; // Pass the searched employee code to the view
            return View("Index", payslips); // Return the Index view with filtered payslips
        }

        // GET: Payslips/DownloadPdf/5
        public async Task<IActionResult> DownloadPdf(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payslip = await _context.Payslips
                .FirstOrDefaultAsync(m => m.PayslipId == id);
            if (payslip == null)
            {
                return NotFound();
            }

            // Generate PDF
            var stream = new MemoryStream();
            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.DefaultTextStyle(x => x.FontSize(12));

                    page.Header()
                        .Text("Payslip Details")
                        .SemiBold().FontSize(24).AlignCenter();

                    page.Content()
                        .PaddingVertical(1, Unit.Centimetre)
                        .Column(col =>
                        {
                            col.Item().Text($"Employee Code: {payslip.EmployeeCode}");
                            col.Item().Text($"Employee Name: {payslip.EmployeeName}");
                            col.Item().Text($"Payment Date: {payslip.PaymentDate.ToShortDateString()}");
                            col.Item().Text($"Company Name: {payslip.CompanyName}");
                            col.Item().Text($"Salary: {payslip.Salary:C}");
                            col.Item().Text($"UIF: {payslip.UIF:C}");
                        });
                });
            });

            document.GeneratePdf(stream);

            // Return the PDF as a file
            return File(stream.ToArray(), "application/pdf", $"Payslip_{payslip.EmployeeCode}.pdf");
        }

        // GET: Payslips/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payslip = await _context.Payslips
                .FirstOrDefaultAsync(m => m.PayslipId == id);
            if (payslip == null)
            {
                return NotFound();
            }

            return View(payslip);
        }

        // GET: Payslips/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Payslips/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PayslipId,EmployeeCode,EmployeeName,PaymentDate,CompanyName,Salary,UIF")] Payslip payslip)
        {
            if (ModelState.IsValid)
            {
                _context.Add(payslip);
                await _context.SaveChangesAsync();

                if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    // Return JSON response for AJAX requests
                    return Json(new { success = true, message = "Payslip created successfully!" });
                }
                else
                {
                    // Redirect to Home/Index for non-AJAX requests
                    return RedirectToAction("Index", "Home");
                }
            }

            // If the model state is invalid, return the view with validation errors
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                // Return JSON response with validation errors for AJAX requests
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return Json(new { success = false, message = "Validation failed.", errors = errors });
            }
            else
            {
                // Return the view with validation errors for non-AJAX requests
                return View(payslip);
            }
        }
        // GET: Payslips/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payslip = await _context.Payslips.FindAsync(id);
            if (payslip == null)
            {
                return NotFound();
            }
            return View(payslip);
        }

        // POST: Payslips/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PayslipId,EmployeeCode,EmployeeName,PaymentDate,CompanyName,Salary,UIF")] Payslip payslip)
        {
            if (id != payslip.PayslipId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(payslip);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PayslipExists(payslip.PayslipId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(payslip);
        }

        // GET: Payslips/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payslip = await _context.Payslips
                .FirstOrDefaultAsync(m => m.PayslipId == id);
            if (payslip == null)
            {
                return NotFound();
            }

            return View(payslip);
        }

        // POST: Payslips/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var payslip = await _context.Payslips.FindAsync(id);
            if (payslip != null)
            {
                _context.Payslips.Remove(payslip);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PayslipExists(int id)
        {
            return _context.Payslips.Any(e => e.PayslipId == id);
        }
    }
}
