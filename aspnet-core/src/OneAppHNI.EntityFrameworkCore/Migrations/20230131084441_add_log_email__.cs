using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OneAppHNI.Migrations
{
    public partial class add_log_email__ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BODY",
                schema: "ONEAPPHNIDB",
                table: "LOGSENDEMAIL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BODY",
                schema: "ONEAPPHNIDB",
                table: "LOGSENDEMAIL",
                type: "NVARCHAR2(2000)",
                nullable: true);
        }
    }
}
