using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OneAppHNI.Migrations
{
    public partial class add_log_call_api : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LOGCALLAPI",
                schema: "ONEAPPHNIDB",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    URL = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: true),
                    METHOD = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: true),
                    DATA = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    KETQUA = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    THOIGIAN = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    IDUSER = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    TenantId = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOGCALLAPI", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LOGCALLAPI",
                schema: "ONEAPPHNIDB");
        }
    }
}
