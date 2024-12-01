using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetCare.Models;
using PetCare.Services;

namespace PetCare.Controllers.Admin
{
    public class DonHangController : Controller
    {

        private readonly ApplicationDbContext context;
        public DonHangController(ApplicationDbContext context)
        {
            this.context = context;
        }
        // GET: DonHangController
        public ActionResult Index()
        {
            var dh = context.Donhangs.ToList();
            return View(dh);
        }

        // GET: DonHangController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var donhang = await context.Donhangs.FirstOrDefaultAsync(dh => dh.id_dh == id);
            if (donhang == null) return NotFound("Không tìm thấy đơn hàng");

            var khachhang = await context.Khachhangs.FirstOrDefaultAsync(kh => kh.id_kh == donhang.id_kh);

            var chitietdon = await context.Chitietdons.Where(ct => ct.id_dh == id)
                .Join(context.Sanphams, ct => ct.id_sp, sp => sp.id_sanpham, (ct, sp) => new ChiTietDonHang
                {
                    id_sp = ct.id_sp,
                    ten_sp = sp.ten_sanpham,
                    so_luong = ct.soluong,
                    gia_sp = sp.thanhtien,
                    thanh_tien = ct.soluong * sp.thanhtien,
                    hinh_anh = sp.hinhanh
                }).ToListAsync();

            var viewModel = new VMChitietdh
            {
                id_dh = donhang.id_dh,
                ten_kh = khachhang.ten_kh,
                sdt_kh = khachhang.sdt_kh,
                diachi_giao = donhang.diachi_giao,
                trang_thai = donhang.trang_thai,
                tong_tien = donhang.tong_tien,
                ngay_tao = donhang.CreateAt,
                ghi_chu = donhang.ghi_chu,
                ma_dh = donhang.ma_dh,
                giohang = chitietdon
            };

            return View(viewModel);
        }

        // GET: DonHangController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DonHangController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DonHangController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DonHangController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DonHangController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DonHangController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
