using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OneAppHNI.Migrations
{
    public partial class add_badcell_ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LOGSENDEMAIL",
                schema: "ONEAPPHNIDB",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    EMAILSEND = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: true),
                    EMAILNHAN = table.Column<string>(type: "NVARCHAR2(2000)", maxLength: 2000, nullable: true),
                    SUBJECT = table.Column<string>(type: "NVARCHAR2(1000)", maxLength: 1000, nullable: true),
                    BODY = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    BODYEMAIL = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    FILEDINHKEM = table.Column<string>(type: "NVARCHAR2(1000)", maxLength: 1000, nullable: true),
                    NGAYGUI = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    NGUOIGUI = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    KETQUA = table.Column<string>(type: "NVARCHAR2(1000)", maxLength: 1000, nullable: true),
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
                    table.PrimaryKey("PK_LOGSENDEMAIL", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LOGSENDEMAIL",
                schema: "ONEAPPHNIDB");
        }
    }
}
