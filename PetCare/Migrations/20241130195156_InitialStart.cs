using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetCare.Migrations
{
    /// <inheritdoc />
    public partial class InitialStart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chitietdongs",
                columns: table => new
                {
                    id_chitietdh = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_dh = table.Column<int>(type: "int", nullable: false),
                    id_sp = table.Column<int>(type: "int", nullable: false),
                    soluong = table.Column<int>(type: "int", nullable: false),
                    ghichu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chitietdongs", x => x.id_chitietdh);
                });

            migrationBuilder.CreateTable(
                name: "Chitietlichs",
                columns: table => new
                {
                    id_ctlich = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_dichvu = table.Column<int>(type: "int", nullable: false),
                    ghichu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    id_lich = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chitietlichs", x => x.id_ctlich);
                });

            migrationBuilder.CreateTable(
                name: "DichVu_CanNangs",
                columns: table => new
                {
                    id_dichvu_can_nang = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_dichvu = table.Column<int>(type: "int", nullable: false),
                    min_can_nang = table.Column<float>(type: "real", nullable: false),
                    max_can_nang = table.Column<float>(type: "real", nullable: false),
                    gia_thanh = table.Column<decimal>(type: "decimal(16,2)", precision: 16, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DichVu_CanNangs", x => x.id_dichvu_can_nang);
                });

            migrationBuilder.CreateTable(
                name: "DichVu_Ngays",
                columns: table => new
                {
                    id_dichvu_ngay = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_dichvu = table.Column<int>(type: "int", nullable: false),
                    gia_thanh = table.Column<decimal>(type: "decimal(16,2)", precision: 16, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DichVu_Ngays", x => x.id_dichvu_ngay);
                });

            migrationBuilder.CreateTable(
                name: "DichVus",
                columns: table => new
                {
                    id_dichvu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ten_dichvu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    dang_dichvu = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DichVus", x => x.id_dichvu);
                });

            migrationBuilder.CreateTable(
                name: "Donhangs",
                columns: table => new
                {
                    id_dh = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ma_dh = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    id_nv = table.Column<int>(type: "int", nullable: false),
                    id_kh = table.Column<int>(type: "int", nullable: false),
                    tong_tien = table.Column<decimal>(type: "decimal(16,2)", precision: 16, scale: 2, nullable: false),
                    trang_thai = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donhangs", x => x.id_dh);
                });

            migrationBuilder.CreateTable(
                name: "Khachhangs",
                columns: table => new
                {
                    id_kh = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ten_kh = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    sdt_kh = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    diachi_kh = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    matkhau = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Khachhangs", x => x.id_kh);
                });

            migrationBuilder.CreateTable(
                name: "Lichhens",
                columns: table => new
                {
                    id_lich = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nhanvien_tiepnhan = table.Column<int>(type: "int", nullable: true),
                    khachhang = table.Column<int>(type: "int", nullable: true),
                    ten_kh = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    sdt_kh = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    thu_cung = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    can_nang = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ngay_hen = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DichVu = table.Column<int>(type: "int", nullable: false),
                    ghi_chu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    tong_tien = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    trang_thai = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lichhens", x => x.id_lich);
                });

            migrationBuilder.CreateTable(
                name: "Nhanviens",
                columns: table => new
                {
                    id_nv = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ten_nv = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    sdt_nv = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    email_nv = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    chucvu_nv = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    matkhau_nv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nhanviens", x => x.id_nv);
                });

            migrationBuilder.CreateTable(
                name: "Sanpham_loais",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    hinh_anh = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sanpham_loais", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Thucungs",
                columns: table => new
                {
                    id_pet = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ten_pet = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ngaysinh_pet = table.Column<DateTime>(type: "datetime2", nullable: false),
                    giong_pet = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    cannang_pet = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    id_kh = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Thucungs", x => x.id_pet);
                });

            migrationBuilder.CreateTable(
                name: "Sanphams",
                columns: table => new
                {
                    id_sanpham = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ten_sanpham = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    id_loaisp = table.Column<int>(type: "int", nullable: false),
                    thanhtien = table.Column<decimal>(type: "decimal(16,2)", precision: 16, scale: 2, nullable: false),
                    soluong = table.Column<int>(type: "int", nullable: false),
                    hinhanh = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ma_sanpham = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sanphams", x => x.id_sanpham);
                    table.ForeignKey(
                        name: "FK_Sanphams_Sanpham_loais_id_loaisp",
                        column: x => x.id_loaisp,
                        principalTable: "Sanpham_loais",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Khohangs",
                columns: table => new
                {
                    id_kho = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_sp = table.Column<int>(type: "int", nullable: false),
                    soluong = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Khohangs", x => x.id_kho);
                    table.ForeignKey(
                        name: "FK_Khohangs_Sanphams_id_sp",
                        column: x => x.id_sp,
                        principalTable: "Sanphams",
                        principalColumn: "id_sanpham",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Khohangs_id_sp",
                table: "Khohangs",
                column: "id_sp");

            migrationBuilder.CreateIndex(
                name: "IX_Sanphams_id_loaisp",
                table: "Sanphams",
                column: "id_loaisp");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chitietdongs");

            migrationBuilder.DropTable(
                name: "Chitietlichs");

            migrationBuilder.DropTable(
                name: "DichVu_CanNangs");

            migrationBuilder.DropTable(
                name: "DichVu_Ngays");

            migrationBuilder.DropTable(
                name: "DichVus");

            migrationBuilder.DropTable(
                name: "Donhangs");

            migrationBuilder.DropTable(
                name: "Khachhangs");

            migrationBuilder.DropTable(
                name: "Khohangs");

            migrationBuilder.DropTable(
                name: "Lichhens");

            migrationBuilder.DropTable(
                name: "Nhanviens");

            migrationBuilder.DropTable(
                name: "Thucungs");

            migrationBuilder.DropTable(
                name: "Sanphams");

            migrationBuilder.DropTable(
                name: "Sanpham_loais");
        }
    }
}
