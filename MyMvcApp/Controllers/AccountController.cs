using Microsoft.AspNetCore.Mvc;
using MyMvcApp.Models;
using System.Linq;

namespace MyMvcApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AccountController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Admin user)
        {
            // Debugging: Check if ModelState is valid
            if (!ModelState.IsValid)
            {
                Console.WriteLine("ModelState is invalid.");
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }

            Console.WriteLine($"Username: {user.Username}");
            Console.WriteLine($"Password: {user.Password}");

            var foundUser = _db.Admins.FirstOrDefault(u => u.Username == user.Username);

            if (foundUser != null)
            {
                Console.WriteLine($"Stored Password: {foundUser.Password}");

                if (user.Password == foundUser.Password)
                {
                    // Authentication successful
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    Console.WriteLine("Password does not match.");
                }
            }
            else
            {
                Console.WriteLine("User not found.");
            }

            ModelState.AddModelError("", "Invalid username or password.");
            return View(user);
        }

        public IActionResult Logout()
        {
            return RedirectToAction("Login");
        }
    }
}