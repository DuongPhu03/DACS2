using Microsoft.EntityFrameworkCore;
using petCare.Models;
using PetCare.Models;

namespace PetCare.Services
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Sanpham_Loai> Sanpham_loais { get; set; }
        public DbSet<Sanpham> Sanphams { get; set; }
        public DbSet<DichVu_CanNang> DichVu_CanNangs { get; set; }
        public DbSet<DichVu_Ngay> DichVu_Ngays { get; set; }
        public DbSet<DichVu> DichVus { get; set; }
        public DbSet<Thucung> Thucungs { get; set; }
        public DbSet<Khachhang> Khachhangs { get; set; }
        public DbSet<Nhanvien> Nhanviens { get; set; }
        public DbSet<Lichhen> Lichhens { get; set; }
        public DbSet<Chitietlich> Chitietlichs { get; set; }
        public DbSet<Donhang> Donhangs { get; set; }
        public DbSet<Chitietdon> Chitietdons { get; set; }
        public DbSet<Khohang> Khohangs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Khohang>()
                .HasOne(k => k.Sanpham)
                .WithMany()
                .HasForeignKey(k => k.id_sp);

            modelBuilder.Entity<Sanpham>()
                .HasOne(sp => sp.sanpham_loai)
                .WithMany()
                .HasForeignKey(sp => sp.id_loaisp);
        }
    }
}
