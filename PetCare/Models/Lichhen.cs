using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PetCare.Models
{
    public class Lichhen
    {
        [Key]
        public int id_lich { get; set; }
        public int? nhanvien_tiepnhan { get; set; }
        public int? khachhang { get; set; } = null;
        [MaxLength(100)]
        public string ten_kh { get; set; } = "";
        [MaxLength(100)]
        public string sdt_kh { get; set; } = "";
        [MaxLength(100)]
        public string? thu_cung { get; set; } = "";
        [MaxLength(100)]
        public string? can_nang { get; set; } = "";
        public DateTime ngay_hen { get; set; }
        public int DichVu { get; set; }
        [MaxLength(100)]
        public string? ghi_chu { get; set; }
        public decimal tong_tien { get; set; }
        public DateTime CreateAt { get; set; }
        [MaxLength(100)]
        public string trang_thai { get; set; } = "";
    }
}
