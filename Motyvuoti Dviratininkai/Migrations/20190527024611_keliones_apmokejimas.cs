using Microsoft.EntityFrameworkCore.Migrations;

namespace Motyvuoti_Dviratininkai.Migrations
{
    public partial class keliones_apmokejimas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kelione_Apmokejimas_ApmokejimasId",
                table: "Kelione");

            migrationBuilder.DropIndex(
                name: "IX_Kelione_ApmokejimasId",
                table: "Kelione");

            migrationBuilder.DropColumn(
                name: "ApmokejimasId",
                table: "Kelione");

            migrationBuilder.AddColumn<int>(
                name: "KelioneId",
                table: "Apmokejimas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Apmokejimas_KelioneId",
                table: "Apmokejimas",
                column: "KelioneId");

            migrationBuilder.AddForeignKey(
                name: "FK_Apmokejimas_Kelione_KelioneId",
                table: "Apmokejimas",
                column: "KelioneId",
                principalTable: "Kelione",
                principalColumn: "KelioneId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apmokejimas_Kelione_KelioneId",
                table: "Apmokejimas");

            migrationBuilder.DropIndex(
                name: "IX_Apmokejimas_KelioneId",
                table: "Apmokejimas");

            migrationBuilder.DropColumn(
                name: "KelioneId",
                table: "Apmokejimas");

            migrationBuilder.AddColumn<int>(
                name: "ApmokejimasId",
                table: "Kelione",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Kelione_ApmokejimasId",
                table: "Kelione",
                column: "ApmokejimasId");

            migrationBuilder.AddForeignKey(
                name: "FK_Kelione_Apmokejimas_ApmokejimasId",
                table: "Kelione",
                column: "ApmokejimasId",
                principalTable: "Apmokejimas",
                principalColumn: "ApmokejimasId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
