using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetCare.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRandom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Chitietdongs",
                table: "Chitietdongs");

            migrationBuilder.RenameTable(
                name: "Chitietdongs",
                newName: "Chitietdons");

            migrationBuilder.AddColumn<string>(
                name: "diachi_giao",
                table: "Donhangs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ghi_chu",
                table: "Donhangs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chitietdons",
                table: "Chitietdons",
                column: "id_chitietdh");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Chitietdons",
                table: "Chitietdons");

            migrationBuilder.DropColumn(
                name: "diachi_giao",
                table: "Donhangs");

            migrationBuilder.DropColumn(
                name: "ghi_chu",
                table: "Donhangs");

            migrationBuilder.RenameTable(
                name: "Chitietdons",
                newName: "Chitietdongs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chitietdongs",
                table: "Chitietdongs",
                column: "id_chitietdh");
        }
    }
}
