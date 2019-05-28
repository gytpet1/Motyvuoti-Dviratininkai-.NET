using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Motyvuoti_Dviratininkai.Migrations
{
    public partial class busenos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Busena",
                table: "Dviratis",
                newName: "DviracioBusenaId");

            migrationBuilder.CreateTable(
                name: "DviracioBusena",
                columns: table => new
                {
                    DviracioBusenaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Busena = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DviracioBusena", x => x.DviracioBusenaId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dviratis_DviracioBusenaId",
                table: "Dviratis",
                column: "DviracioBusenaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dviratis_DviracioBusena_DviracioBusenaId",
                table: "Dviratis",
                column: "DviracioBusenaId",
                principalTable: "DviracioBusena",
                principalColumn: "DviracioBusenaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dviratis_DviracioBusena_DviracioBusenaId",
                table: "Dviratis");

            migrationBuilder.DropTable(
                name: "DviracioBusena");

            migrationBuilder.DropIndex(
                name: "IX_Dviratis_DviracioBusenaId",
                table: "Dviratis");

            migrationBuilder.RenameColumn(
                name: "DviracioBusenaId",
                table: "Dviratis",
                newName: "Busena");
        }
    }
}
