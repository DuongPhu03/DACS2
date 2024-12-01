using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetCare.Models;
using PetCare.Services;

namespace PetCare.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IWebHostEnvironment environment;

        public AppointmentsController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            this.context = context;
            this.environment = environment;
        }
        public IActionResult Information()
        {
            ViewBag.DichVuOption = new List<SelectListItem>
            {
                new SelectListItem { Value = "", Text = "-- Chọn Dịch Vụ --" },
                new SelectListItem { Value = "1", Text = "Cắt Tỉa Tóc" },
                new SelectListItem { Value = "2", Text = "Cạo Lông" },
            };
            return View();
        }

        /*[HttpPost]
        public ActionResult Create(DichVu_CanNangDto dv_cndto)
        {
            if (!ModelState.IsValid)
            {
                ViewData["IDDV"] = dv_cndto.id_dichvu; // Preserve IDKH in case of errors
                return View(dv_cndto);
            }

            var dichvu_cns = new DichVu_CanNang
            {
                id_dichvu = dv_cndto.id_dichvu,
                min_can_nang = dv_cndto.min_can_nang,
                max_can_nang = dv_cndto.max_can_nang,
                gia_thanh = dv_cndto.gia_thanh
            };

            context.DichVu_CanNangs.Add(dichvu_cns);
            context.SaveChanges();

            return RedirectToAction("Detail", "DichVu", new { id = dichvu_cns.id_dichvu });
        }*/

        [HttpPost]
        public ActionResult Information(LichhenDto lichhenDto)
        {
            if (!ModelState.IsValid)
            {
                return View(lichhenDto);
            }

            var lichhen = new Lichhen
            {
                ten_kh = lichhenDto.ten_kh,
                sdt_kh = lichhenDto.sdt_kh,
                ngay_hen = lichhenDto.ngay_hen,
                DichVu = lichhenDto.DichVu,
                CreateAt = DateTime.Today.ToLocalTime(),
                trang_thai = "Đang chờ xác nhận"
            };

            context.Lichhens.Add(lichhen);
            context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

    }
}
