using System.ComponentModel.DataAnnotations;

namespace PetCare.Models
{
    public class SanphamDto
    {
        [Required, MaxLength(100)]
        public string ten_sanpham { get; set; } = "";
        [Required]
        public int id_loaisp { get; set; }
        [Required]
        public decimal thanhtien { get; set; }
        public int soluong { get; set; } = 0;
        public IFormFile? hinhanh { get; set; }
        public string ma_sanpham { get; set; } = "";
    }
}
