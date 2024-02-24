using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop_API.Migrations
{
    public partial class testrole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SanPhamYeuThich_AspNetUsers_NguoiDungId1",
                table: "SanPhamYeuThich");

            migrationBuilder.AlterColumn<string>(
                name: "NguoiDungId1",
                table: "SanPhamYeuThich",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "GiaGoc",
                table: "GioHangChiTiet",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "GiaBan",
                table: "GioHangChiTiet",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_SanPhamYeuThich_AspNetUsers_NguoiDungId1",
                table: "SanPhamYeuThich",
                column: "NguoiDungId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SanPhamYeuThich_AspNetUsers_NguoiDungId1",
                table: "SanPhamYeuThich");

            migrationBuilder.AlterColumn<string>(
                name: "NguoiDungId1",
                table: "SanPhamYeuThich",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "GiaGoc",
                table: "GioHangChiTiet",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "GiaBan",
                table: "GioHangChiTiet",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddForeignKey(
                name: "FK_SanPhamYeuThich_AspNetUsers_NguoiDungId1",
                table: "SanPhamYeuThich",
                column: "NguoiDungId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
