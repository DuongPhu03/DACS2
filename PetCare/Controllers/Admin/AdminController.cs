using Microsoft.AspNetCore.Mvc;
using PetCare.Models.Authentication;

namespace PetCare.Controllers.Admin
{
    public class AdminController : Controller
    {
        [Authentication]
        public IActionResult Index()
        {
            return View();
        }
    }
}
