using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetCare.Migrations
{
    /// <inheritdoc />
    public partial class FixDBContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chitietlich_Donhangs_id_dh",
                table: "Chitietlich");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Chitietlich",
                table: "Chitietlich");

            migrationBuilder.RenameTable(
                name: "Chitietlich",
                newName: "Chitietdons");

            migrationBuilder.RenameIndex(
                name: "IX_Chitietlich_id_dh",
                table: "Chitietdons",
                newName: "IX_Chitietdons_id_dh");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chitietdons",
                table: "Chitietdons",
                column: "id_chitietdh");

            migrationBuilder.AddForeignKey(
                name: "FK_Chitietdons_Donhangs_id_dh",
                table: "Chitietdons",
                column: "id_dh",
                principalTable: "Donhangs",
                principalColumn: "id_dh",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chitietdons_Donhangs_id_dh",
                table: "Chitietdons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Chitietdons",
                table: "Chitietdons");

            migrationBuilder.RenameTable(
                name: "Chitietdons",
                newName: "Chitietlich");

            migrationBuilder.RenameIndex(
                name: "IX_Chitietdons_id_dh",
                table: "Chitietlich",
                newName: "IX_Chitietlich_id_dh");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chitietlich",
                table: "Chitietlich",
                column: "id_chitietdh");

            migrationBuilder.AddForeignKey(
                name: "FK_Chitietlich_Donhangs_id_dh",
                table: "Chitietlich",
                column: "id_dh",
                principalTable: "Donhangs",
                principalColumn: "id_dh",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
