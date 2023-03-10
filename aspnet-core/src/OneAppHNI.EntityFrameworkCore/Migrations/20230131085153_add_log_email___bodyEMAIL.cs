using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OneAppHNI.Migrations
{
    public partial class add_log_email___bodyEMAIL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BODYEMAIL",
                schema: "ONEAPPHNIDB",
                table: "LOGSENDEMAIL",
                type: "NVARCHAR2(2000)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BODYEMAIL",
                schema: "ONEAPPHNIDB",
                table: "LOGSENDEMAIL");
        }
    }
}
