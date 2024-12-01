using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PetCare.Models;
using PetCare.Models.Authentication;
using PetCare.Services;

namespace PetCare.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IWebHostEnvironment environment;
        public AccountController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            this.context = context;
            this.environment = environment;
        }
        public IActionResult Login()
        {
            if(HttpContext.Session.GetInt32("Username") == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public IActionResult Login(VMTaiKhoan taikhoan)
        {
            if(HttpContext.Session.GetInt32("Username") == null)
            {
                var userKH = context.Khachhangs.FirstOrDefault(kh => (kh.sdt_kh.Equals(taikhoan.Username) == true) && kh.matkhau == taikhoan.Password);

                var userNV = context.Nhanviens.FirstOrDefault(nv => (nv.sdt_nv.Equals(taikhoan.Username) == true) && nv.matkhau_nv == taikhoan.Password);

                if (userKH != null)
                {
                    HttpContext.Session.SetInt32("Username", userKH.id_kh);
                    return RedirectToAction("Index");
                }

                if (userNV != null)
                {
                    HttpContext.Session.SetInt32("Username", userNV.id_nv);
                    HttpContext.Session.SetString("ChucVu", userNV.chucvu_nv);
                    return RedirectToAction("Index", "Admin");
                }
            }
            ModelState.AddModelError("", "Tài khoản không tìm thấy");
            return View(taikhoan);
        }
        [HttpGet]
        public IActionResult Register()
        {

            return View(); 
        }

        [HttpPost]
        public async Task<IActionResult> Register(KhachhangDto khachhangDto)
        {
            if(context.Khachhangs.Any(kh => kh.diachi_kh == khachhangDto.diachi_kh || kh.sdt_kh == khachhangDto.sdt_kh))
            {
                ModelState.AddModelError("", "Email or Phone already exists.");
                return View(khachhangDto);
            }

            var khachhang = new Khachhang
            {
                ten_kh = khachhangDto.ten_kh,
                sdt_kh = khachhangDto.sdt_kh,
                diachi_kh = khachhangDto.diachi_kh,
                matkhau = khachhangDto.matkhau_kh
            };

            context.Add(khachhang);
            await context.SaveChangesAsync();

            return RedirectToAction("Login", "Account");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); // Clear all session data
            HttpContext.Session.Remove("Username");
            return RedirectToAction("Login", "Account");
        }
    }
}
