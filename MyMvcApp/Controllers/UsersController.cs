using Microsoft.AspNetCore.Mvc;

namespace MyMvcApp.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
