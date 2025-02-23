using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyMvcApp.Models;

namespace MyMvcApp.Controllers
{
    public class RegisterLogin : Controller
    {
        private readonly ApplicationDbContext _context;

        public RegisterLogin(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Account/RegisterLogin
        public IActionResult Registration()
        {
            return View();
        }


        // POST: Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(User user)
        {
            if (ModelState.IsValid)
            {
                // Check if the email is already registered
                if (_context.Users.Any(u => u.Email == user.Email))
                {
                    ModelState.AddModelError("Email", "Email is already registered.");
                    return View("RegisterLogin", user);
                }

                // Hash the password (use a proper hashing library like BCrypt)
                user.Password = HashPassword(user.Password);

                _context.Add(user);
                await _context.SaveChangesAsync();

                // Redirect to a success page or login page
                return RedirectToAction("Index", "Users");
            }

            // If validation fails, return to the registration form
            return View("RegisterLogin", user);
        }

        // POST: Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string Email, string Password)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == Email);

            if (user == null || !VerifyPassword(Password, user.Password))
            {
                ModelState.AddModelError(string.Empty, "Invalid email or password.");
                return View("RegisterLogin");
            }

            // Log the user in (e.g., set authentication cookie)
            // Redirect to a dashboard or home page
            return RedirectToAction("Index", "Users");
        }

        // Helper method to hash passwords (use a proper library like BCrypt)
        private string HashPassword(string password)
        {
            // Implement password hashing logic here
            return password; // Replace with actual hashing
        }

        // Helper method to verify passwords
        private bool VerifyPassword(string inputPassword, string hashedPassword)
        {
            // Implement password verification logic here
            return inputPassword == hashedPassword; // Replace with actual verification
        }
    }
}