using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OneAppHNI.Migrations
{
    public partial class add_log_email___noidung : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BODY",
                schema: "ONEAPPHNIDB",
                table: "LOGSENDEMAIL",
                newName: "NOIDUNG");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NOIDUNG",
                schema: "ONEAPPHNIDB",
                table: "LOGSENDEMAIL",
                newName: "BODY");
        }
    }
}
