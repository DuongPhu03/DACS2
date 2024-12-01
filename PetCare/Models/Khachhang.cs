using System.ComponentModel.DataAnnotations;

namespace PetCare.Models
{
    public class Khachhang
    {
        [Key]
        public int id_kh { get; set; }
        [MaxLength(100)]
        public string ten_kh { get; set; } = "";
        [MaxLength(100)]
        public string sdt_kh {  get; set; } = "";
        [MaxLength(100)]
        public string diachi_kh { get; set; } = "";
        public string matkhau {  get; set; } = "";
    }
}
