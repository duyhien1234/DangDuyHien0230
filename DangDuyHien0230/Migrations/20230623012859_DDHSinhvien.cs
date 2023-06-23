using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DangDuyHien0230.Migrations
{
    /// <inheritdoc />
    public partial class DDHSinhvien : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DDHSinhvien",
                columns: table => new
                {
                    Sinhvien = table.Column<string>(type: "TEXT", nullable: false),
                    Truong = table.Column<string>(type: "TEXT", nullable: false),
                    Thanhpho = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DDHSinhvien", x => x.Sinhvien);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DDHSinhvien");
        }
    }
}
