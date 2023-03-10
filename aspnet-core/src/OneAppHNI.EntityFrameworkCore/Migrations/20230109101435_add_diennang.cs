using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OneAppHNI.Migrations
{
    public partial class add_diennang : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LOAIFILE",
                schema: "ONEAPPHNIDB",
                table: "LOGUPLOADFILE",
                type: "NVARCHAR2(200)",
                maxLength: 200,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LOAIFILE",
                schema: "ONEAPPHNIDB",
                table: "LOGUPLOADFILE");
        }
    }
}
