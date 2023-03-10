using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OneAppHNI.Migrations
{
    public partial class add_badcell : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LOGSENDEMAIL",
                schema: "ONEAPPHNIDB");

            migrationBuilder.CreateTable(
                name: "BADCELL",
                schema: "ONEAPPHNIDB",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    MATINH = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true),
                    DONVI = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    QUANHUYEN = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    TENTRAM = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    TENCELL = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    CELLID = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    LOAICELL = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true),
                    QOSDIEM = table.Column<double>(type: "BINARY_DOUBLE", nullable: true),
                    QOSTYLE = table.Column<double>(type: "BINARY_DOUBLE", nullable: true),
                    SQICHUANHOA1 = table.Column<double>(type: "BINARY_DOUBLE", nullable: true),
                    SQICHUANHOA2 = table.Column<double>(type: "BINARY_DOUBLE", nullable: true),
                    SQICHUANHOA3 = table.Column<double>(type: "BINARY_DOUBLE", nullable: true),
                    SQICHUANHOA4 = table.Column<double>(type: "BINARY_DOUBLE", nullable: true),
                    SQICHUANHOA5 = table.Column<double>(type: "BINARY_DOUBLE", nullable: true),
                    SQIDIEM1 = table.Column<double>(type: "BINARY_DOUBLE", nullable: true),
                    SQIDIEM2 = table.Column<double>(type: "BINARY_DOUBLE", nullable: true),
                    SQIDIEM3 = table.Column<double>(type: "BINARY_DOUBLE", nullable: true),
                    SQIDIEM4 = table.Column<double>(type: "BINARY_DOUBLE", nullable: true),
                    SQIDIEM5 = table.Column<double>(type: "BINARY_DOUBLE", nullable: true),
                    KPIDAURASQI1 = table.Column<double>(type: "BINARY_DOUBLE", nullable: true),
                    KPIDAURASQI2 = table.Column<double>(type: "BINARY_DOUBLE", nullable: true),
                    KPIDAURASQI3 = table.Column<double>(type: "BINARY_DOUBLE", nullable: true),
                    KPIDAURASQI4 = table.Column<double>(type: "BINARY_DOUBLE", nullable: true),
                    KPIDAURASQI5 = table.Column<double>(type: "BINARY_DOUBLE", nullable: true),
                    KPIDAUVAOSQI1 = table.Column<double>(type: "BINARY_DOUBLE", nullable: true),
                    KPIDAUVAOSQI2 = table.Column<double>(type: "BINARY_DOUBLE", nullable: true),
                    KPIDAUVAOSQI3 = table.Column<double>(type: "BINARY_DOUBLE", nullable: true),
                    KPIDAUVAOSQI4 = table.Column<double>(type: "BINARY_DOUBLE", nullable: true),
                    KPIDAUVAOSQI5 = table.Column<double>(type: "BINARY_DOUBLE", nullable: true),
                    KPIDAUVAOOUTDOR = table.Column<double>(type: "BINARY_DOUBLE", nullable: true),
                    TRAFFIC = table.Column<double>(type: "BINARY_DOUBLE", nullable: true),
                    TUANBAOCAO = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    NAMBAOCAO = table.Column<int>(type: "NUMBER(10)", nullable: false),
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
                    table.PrimaryKey("PK_BADCELL", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BADCELL",
                schema: "ONEAPPHNIDB");

            migrationBuilder.CreateTable(
                name: "LOGSENDEMAIL",
                schema: "ONEAPPHNIDB",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    BODY = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    BODYEMAIL = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    DeleterUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    EMAILNHAN = table.Column<string>(type: "NVARCHAR2(2000)", maxLength: 2000, nullable: true),
                    EMAILSEND = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: true),
                    FILEDINHKEM = table.Column<string>(type: "NVARCHAR2(1000)", maxLength: 1000, nullable: true),
                    IsDeleted = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    KETQUA = table.Column<string>(type: "NVARCHAR2(1000)", maxLength: 1000, nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    NGAYGUI = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    NGUOIGUI = table.Column<long>(type: "NUMBER(19)", nullable: true),
                    SUBJECT = table.Column<string>(type: "NVARCHAR2(1000)", maxLength: 1000, nullable: true),
                    TenantId = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOGSENDEMAIL", x => x.Id);
                });
        }
    }
}
