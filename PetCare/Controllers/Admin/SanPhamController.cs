using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetCare.Models;
using PetCare.Services;

namespace PetCare.Controllers.Admin
{
    public class SanPhamController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IWebHostEnvironment environment;
        public SanPhamController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            this.context = context;
            this.environment = environment;
        }
        public async Task<IActionResult> Index()
        {
            var SPData = await context.Sanphams
                .Include(sp => sp.sanpham_loai)
                .Select(sp => new VMSanPham
                {
                    id_sanpham = sp.id_sanpham,
                    ten_sanpham = sp.ten_sanpham,
                    loai_sanpham = sp.sanpham_loai.name,
                    hinhanh = sp.hinhanh,
                    soluong = sp.soluong,
                    ma_sanpham = sp.ma_sanpham,
                    thanhtien = sp.thanhtien
                })
                .ToListAsync();

            return View(SPData);
        }

        public IActionResult Create()
        {
            ViewBag.LoaiSP = context.Sanpham_loais.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(SanphamDto sanphamDto)
        {
            if (sanphamDto.hinhanh == null)
            {
                ModelState.AddModelError("ImageFile", "The image file is required");
            }

            if (!ModelState.IsValid)
            {
                return View(sanphamDto);
            }

            //Lưu hình ảnh
            string newFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            newFileName += Path.GetExtension(sanphamDto.hinhanh!.FileName);
            string imageFullPath = environment.WebRootPath + "/assets/sanphams/" + newFileName;
            using (var steam = System.IO.File.Create(imageFullPath))
            {
                sanphamDto.hinhanh.CopyTo(steam);
            }

            //Thêm vô CSDL
            Sanpham sanpham = new Sanpham
            {
                ten_sanpham = sanphamDto.ten_sanpham,
                id_loaisp = sanphamDto.id_loaisp,
                thanhtien = sanphamDto.thanhtien,
                soluong = sanphamDto.soluong,
                hinhanh = newFileName,
                ma_sanpham = sanphamDto.ma_sanpham,
            };

            context.Sanphams.Add(sanpham);
            context.SaveChanges();

            return RedirectToAction("Index", "SanPham");
        }

        public IActionResult Edit(int id)
        {
            ViewBag.LoaiSP = context.Sanpham_loais.ToList();
            var sanpham = context.Sanphams.Find(id);
            if (sanpham == null)
            {
                return RedirectToAction("Index", "SanPham");
            }

            //tạo sanphamDto lên sanpham
            var sanphamDto = new SanphamDto()
            {
                ten_sanpham = sanpham.ten_sanpham,
                id_loaisp = sanpham.id_loaisp,
                thanhtien = sanpham.thanhtien,
                soluong = sanpham.soluong,
                ma_sanpham = sanpham.ma_sanpham,
            };

            ViewData["sanphamId"] = sanpham.id_sanpham;
            ViewData["ImageFileName"] = sanpham.hinhanh;

            return View(sanphamDto);
        }

        [HttpPost]
        public IActionResult Edit(int id, SanphamDto sanphamDto)
        {
            var sanpham = context.Sanphams.Find(id);

            if (sanpham == null)
            {
                return RedirectToAction("Index", "SanPham");
            }

            if (!ModelState.IsValid)
            {
                ViewData["sanphamId"] = sanpham.id_sanpham;
                ViewData["ImageFileName"] = sanpham.hinhanh;

                return View(sanphamDto);
            }

            string newFileName = sanpham.hinhanh;
            if (sanphamDto.hinhanh != null)
            {
                newFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                newFileName += Path.GetExtension(sanphamDto.hinhanh.FileName);
                string imageFullPath = environment.WebRootPath + "/assets/sanphams/" + newFileName;
                using (var steam = System.IO.File.Create(imageFullPath))
                {
                    sanphamDto.hinhanh.CopyTo(steam);
                }

                string oldImageFullPath = environment.WebRootPath + "/assets/sanphams/" + sanpham.hinhanh;
                System.IO.File.Delete(oldImageFullPath);
            }

            sanpham.ten_sanpham = sanphamDto.ten_sanpham;
            sanpham.id_loaisp = sanphamDto.id_loaisp;
            sanpham.thanhtien = sanphamDto.thanhtien;
            sanpham.soluong = sanphamDto.soluong;
            sanpham.hinhanh = newFileName;
            sanpham.ma_sanpham = sanphamDto.ma_sanpham;

            context.SaveChanges();

            return RedirectToAction("Index", "SanPham");
        }
        public IActionResult Delete(int id)
        {
            var sanpham = context.Sanphams.Find(id);
            if (sanpham == null)
            {
                return RedirectToAction("Index", "SanPham");
            }

            string imageFullPath = environment.WebRootPath + "/assets/sanphams/" + sanpham.hinhanh;
            System.IO.File.Delete(imageFullPath);

            context.Sanphams.Remove(sanpham);
            context.SaveChanges();

            return RedirectToAction("Index", "SanPham");
        }
    }
}
