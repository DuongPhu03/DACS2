using Microsoft.AspNetCore.Mvc;

namespace PetCare.Controllers.Admin
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
