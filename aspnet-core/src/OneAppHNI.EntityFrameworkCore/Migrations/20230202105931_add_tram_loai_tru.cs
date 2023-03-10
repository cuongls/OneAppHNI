using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OneAppHNI.Migrations
{
    public partial class add_tram_loai_tru : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TRAMLOAITRU",
                schema: "ONEAPPHNIDB",
                columns: table => new
                {
                    Id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    QUANHUYEN = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    LATITUDE = table.Column<double>(type: "BINARY_DOUBLE", nullable: true),
                    LONGITUDE = table.Column<double>(type: "BINARY_DOUBLE", nullable: true),
                    LOAITRAM = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    SITENAME = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    CELLNAME = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    CELLNAMEALIAS = table.Column<string>(type: "NVARCHAR2(1000)", maxLength: 1000, nullable: true),
                    TRANGTHAI = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: true),
                    THOIGIAN = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    GHICHU = table.Column<string>(type: "NVARCHAR2(2000)", maxLength: 2000, nullable: true),
                    ISACTIVE = table.Column<bool>(type: "NUMBER(1)", nullable: false),
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
                    table.PrimaryKey("PK_TRAMLOAITRU", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TRAMLOAITRU",
                schema: "ONEAPPHNIDB");
        }
    }
}
