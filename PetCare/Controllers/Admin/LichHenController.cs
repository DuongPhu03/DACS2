using Microsoft.AspNetCore.Mvc;
using PetCare.Services;

namespace PetCare.Controllers.Admin
{
    public class LichHenController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IWebHostEnvironment environment;
        public LichHenController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            this.context = context;
            this.environment = environment;
        }
        public IActionResult Index()
        {
            var lichhen = context.Lichhens.OrderBy(lh => lh.id_lich).ToList();
            return View(lichhen);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }
        public IActionResult Details(int id)
        {
            return View();
        }
        public IActionResult Delete()
        {
            return View();
        }
    }
}
