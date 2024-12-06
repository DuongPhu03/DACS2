using Humanizer;
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
            // Store the previous page URL before showing the login page
            if (HttpContext.Session.GetString("PreviousUrl") == null)
            {
                HttpContext.Session.SetString("PreviousUrl", HttpContext.Request.Headers["Referer"].ToString());
            }

            if (HttpContext.Session.GetInt32("Username") == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Shop");
            }
        }
        [HttpPost]
        public IActionResult Login(VMTaiKhoan taikhoan)
        {
            if (HttpContext.Session.GetInt32("Username") == null)
            {
                var userKH = context.Khachhangs.FirstOrDefault(kh => (kh.sdt_kh.Equals(taikhoan.Username) == true) || (kh.diachi_kh.Equals(taikhoan.Username) && kh.matkhau == taikhoan.Password));

                var userNV = context.Nhanviens.FirstOrDefault(nv => (nv.sdt_nv.Equals(taikhoan.Username) == true) || (nv.email_nv.Equals(taikhoan.Username) && nv.matkhau_nv == taikhoan.Password));

                if (userKH != null)
                {
                    HttpContext.Session.SetInt32("Username", userKH.id_kh);

                    // Check the previous URL, but do not allow redirect to Admin page if the user is a customer (KH)
                    var previousUrl = HttpContext.Session.GetString("PreviousUrl");
                    if (!string.IsNullOrEmpty(previousUrl) && !previousUrl.Contains("/Admin"))
                    {
                        return Redirect(previousUrl); // Redirect to previous URL if valid and not an Admin page
                    }

                    return RedirectToAction("Index", "Shop"); // Default redirect to the Shop page
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

        public async Task<IActionResult> Profile()
        {
            int? userId = HttpContext.Session.GetInt32("Username");
            if (userId == null)
            {
                HttpContext.Session.Clear();
            }
            var user = await context.Khachhangs.FindAsync(userId);

            ViewData["UserId"] = user?.id_kh;
            ViewData["UserName"] = user?.ten_kh;

            var khachhangDto = new KhachhangDto
            {
                ten_kh = user.ten_kh,
                sdt_kh = user.sdt_kh,
                diachi_kh = user.diachi_kh
            };

            return View(khachhangDto);
        }

        [HttpPost]
        public async Task<IActionResult> Profile(KhachhangDto dto)
        {
            int? userId = HttpContext.Session.GetInt32("Username");

            var khachhang = await context.Khachhangs.FindAsync(userId);

            if (khachhang == null)
            {
                return RedirectToAction("Profile", "Account");
            }

            if (!ModelState.IsValid)
            {
                ViewData["UserId"] = khachhang.id_kh;
                ViewData["UserName"] = khachhang.ten_kh;
                return View(dto);
            }

            // Update employee details
            khachhang.ten_kh = dto.ten_kh;
            khachhang.sdt_kh = dto.sdt_kh;
            khachhang.diachi_kh = dto.diachi_kh;

            // Update password only if a new password is provided
            if (!string.IsNullOrEmpty(dto.matkhau_kh))
            {
                khachhang.matkhau = dto.matkhau_kh;
            }

            await context.SaveChangesAsync();

            return RedirectToAction("Profile", "Account");
        }

        public async Task<IActionResult> Orders()
        {
            int? userId = HttpContext.Session.GetInt32("Username");

            if (userId == null)
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Login", "Account"); // Redirect to login if user is not authenticated
            }

            var user = await context.Khachhangs.FindAsync(userId);

            if (user == null)
            {
                TempData["Error"] = "Customer not found.";
                return RedirectToAction("Index", "Home");
            }

            ViewData["UserId"] = user.id_kh;
            ViewData["UserName"] = user.ten_kh;

            // Query orders for the logged-in user
            var donhang = await context.Donhangs
                .Where(dh => dh.id_kh == userId) // Filter by userId
                .Include(dh => dh.Khachhang) // Include Khachhang for related data
                .Select(dh => new VMChitietdh
                {
                    id_dh = dh.id_dh,
                    sdt_kh = dh.Khachhang.sdt_kh,
                    diachi_giao = dh.diachi_giao,
                    tong_tien = dh.tong_tien,
                    ngay_tao = dh.CreateAt,
                    trang_thai = dh.trang_thai,
                    ghi_chu = dh.ghi_chu,
                    ma_dh = dh.ma_dh,
                })
                .ToListAsync();

            return View(donhang); // Pass the filtered orders to the view
        }

        [HttpPost]
        public async Task<IActionResult> Cancel(int id)
        {
            int? userId = HttpContext.Session.GetInt32("Username");
            if (userId == null)
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Login", "Account"); // Redirect to login if user is not authenticated
            }

            // Find the order
            var order = await context.Donhangs.FirstOrDefaultAsync(dh => dh.id_dh == id && dh.id_kh == userId);

            if (order == null)
            {
                TempData["Error"] = "Order not found or you do not have permission to cancel it.";
                return RedirectToAction("Orders");
            }

            // Update the status to "Đã Hủy"
            order.trang_thai = "Hủy đơn";

            // Save changes to the database
            await context.SaveChangesAsync();

            TempData["Success"] = "Order has been canceled.";
            return RedirectToAction("Orders");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); // Clear all session data
            HttpContext.Session.Remove("Username");
            HttpContext.Session.Remove("PreviousUrl"); // Clear the stored previous URL
            return RedirectToAction("Login", "Account");
        }
    }
}
