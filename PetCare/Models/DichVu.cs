using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PetCare.Models
{
    public class DichVu
    {
        [Key]
        public int id_dichvu { get; set; }
        [MaxLength(100)]
        public string? ten_dichvu { get; set; }
        public int dang_dichvu { get; set; }
    }
}
