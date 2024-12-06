using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetCare.Migrations
{
    /// <inheritdoc />
    public partial class FixLichHèn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "ghi_chu",
                table: "Lichhens",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "id_nv",
                table: "Lichhens",
                type: "int",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chitietlich_Donhangs_id_dh",
                table: "Chitietlich");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Chitietlich",
                table: "Chitietlich");

            migrationBuilder.DropColumn(
                name: "id_nv",
                table: "Lichhens");

            migrationBuilder.RenameTable(
                name: "Chitietlich",
                newName: "Chitietdons");

            migrationBuilder.RenameIndex(
                name: "IX_Chitietlich_id_dh",
                table: "Chitietdons",
                newName: "IX_Chitietdons_id_dh");

            migrationBuilder.AlterColumn<string>(
                name: "ghi_chu",
                table: "Lichhens",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
    }
}
