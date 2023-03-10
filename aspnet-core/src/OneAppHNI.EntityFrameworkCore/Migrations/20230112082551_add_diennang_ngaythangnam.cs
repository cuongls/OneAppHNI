using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OneAppHNI.Migrations
{
    public partial class add_diennang_ngaythangnam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NAMBAOCAO",
                schema: "ONEAPPHNIDB",
                table: "DIENNANG",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NGAYBAOCAO",
                schema: "ONEAPPHNIDB",
                table: "DIENNANG",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "THANGBAOCAO",
                schema: "ONEAPPHNIDB",
                table: "DIENNANG",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NAMBAOCAO",
                schema: "ONEAPPHNIDB",
                table: "DIENNANG");

            migrationBuilder.DropColumn(
                name: "NGAYBAOCAO",
                schema: "ONEAPPHNIDB",
                table: "DIENNANG");

            migrationBuilder.DropColumn(
                name: "THANGBAOCAO",
                schema: "ONEAPPHNIDB",
                table: "DIENNANG");
        }
    }
}
