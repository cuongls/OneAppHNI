using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OneAppHNI.Migrations
{
    public partial class add_diennang_fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DIENNANG",
                schema: "ONEAPPHNIDB",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    MACSHT = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: true),
                    TTVT = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: true),
                    DOIVT = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: true),
                    MUCDICHSD = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: true),
                    TENTRAM = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: true),
                    LOAIHINHTH = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: true),
                    SODIEN = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    TIENDIEN = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    CPVANHANH = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    CPTHUEHATANG = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    CPLAODONG = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    CPSUACHUA = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    CPKHAC = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    MAHOADON = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: true),
                    CHUNGCSHT = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: true),
                    GHICHU = table.Column<string>(type: "NVARCHAR2(1000)", maxLength: 1000, nullable: true),
                    TRANGTHAI = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: true),
                    NETXXACNHAN = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: true),
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
                    table.PrimaryKey("PK_DIENNANG", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DIENNANG",
                schema: "ONEAPPHNIDB");
        }
    }
}
