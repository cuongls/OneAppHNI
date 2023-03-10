using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OneAppHNI.Migrations
{
    public partial class LOG_FILE_edituser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "IDUSER",
                schema: "ONEAPPHNIDB",
                table: "LOGUPLOADFILE",
                type: "NUMBER(19)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "IDUSER",
                schema: "ONEAPPHNIDB",
                table: "LOGUPLOADFILE",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(long),
                oldType: "NUMBER(19)",
                oldNullable: true);
        }
    }
}
