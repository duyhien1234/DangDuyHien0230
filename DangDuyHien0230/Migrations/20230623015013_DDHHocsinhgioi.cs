using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DangDuyHien0230.Migrations
{
    /// <inheritdoc />
    public partial class DDHHocsinhgioi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DDHHocsinhgioi",
                columns: table => new
                {
                    Ketqua = table.Column<string>(type: "TEXT", nullable: false),
                    Sinhvien = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DDHHocsinhgioi", x => x.Ketqua);
                    table.ForeignKey(
                        name: "FK_DDHHocsinhgioi_DDHSinhvien_Sinhvien",
                        column: x => x.Sinhvien,
                        principalTable: "DDHSinhvien",
                        principalColumn: "Sinhvien",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DDHHocsinhgioi_Sinhvien",
                table: "DDHHocsinhgioi",
                column: "Sinhvien");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DDHHocsinhgioi");
        }
    }
}
