using Microsoft.EntityFrameworkCore.Migrations;

namespace Motyvuoti_Dviratininkai.Migrations
{
    public partial class aikstele_adresas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Adresas",
                table: "Aikstele",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adresas",
                table: "Aikstele");
        }
    }
}
