using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Motyvuoti_Dviratininkai.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Apmokejimas",
                columns: table => new
                {
                    ApmokejimasId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<DateTime>(nullable: false),
                    Suma = table.Column<double>(nullable: false),
                    arApmoketas = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apmokejimas", x => x.ApmokejimasId);
                });

            migrationBuilder.CreateTable(
                name: "Darbuotojas",
                columns: table => new
                {
                    DarbuotojasId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Vardas = table.Column<string>(nullable: true),
                    elPastas = table.Column<string>(nullable: true),
                    Slaptazodis = table.Column<string>(nullable: true),
                    Pavarde = table.Column<string>(nullable: true),
                    tabelioNr = table.Column<string>(nullable: true),
                    Pareigos = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Darbuotojas", x => x.DarbuotojasId);
                });

            migrationBuilder.CreateTable(
                name: "Klientas",
                columns: table => new
                {
                    KlientasId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    elPastas = table.Column<string>(nullable: true),
                    Slaptazodis = table.Column<string>(nullable: true),
                    telNumeris = table.Column<string>(nullable: true),
                    Pavarde = table.Column<string>(nullable: true),
                    Vardas = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klientas", x => x.KlientasId);
                });

            migrationBuilder.CreateTable(
                name: "Pasiekimas",
                columns: table => new
                {
                    PasiekimasId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Pavadinimas = table.Column<string>(nullable: true),
                    Kilometrai = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pasiekimas", x => x.PasiekimasId);
                });

            migrationBuilder.CreateTable(
                name: "Aikstele",
                columns: table => new
                {
                    AiksteleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    vietuSkaicius = table.Column<int>(nullable: false),
                    laisvuVietuSkacius = table.Column<int>(nullable: false),
                    Latitude = table.Column<float>(nullable: false),
                    Longtitude = table.Column<float>(nullable: false),
                    DarbuotojasId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aikstele", x => x.AiksteleId);
                    table.ForeignKey(
                        name: "FK_Aikstele_Darbuotojas_DarbuotojasId",
                        column: x => x.DarbuotojasId,
                        principalTable: "Darbuotojas",
                        principalColumn: "DarbuotojasId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Iskvietimas",
                columns: table => new
                {
                    IskvietimasId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Apibudinimas = table.Column<string>(nullable: true),
                    KlientasId = table.Column<int>(nullable: false),
                    DarbuotojasId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Iskvietimas", x => x.IskvietimasId);
                    table.ForeignKey(
                        name: "FK_Iskvietimas_Darbuotojas_DarbuotojasId",
                        column: x => x.DarbuotojasId,
                        principalTable: "Darbuotojas",
                        principalColumn: "DarbuotojasId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Iskvietimas_Klientas_KlientasId",
                        column: x => x.KlientasId,
                        principalTable: "Klientas",
                        principalColumn: "KlientasId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Marsrutas",
                columns: table => new
                {
                    MarsrutasId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Pavadinimas = table.Column<string>(nullable: true),
                    Kategorija = table.Column<string>(nullable: true),
                    Miestas = table.Column<string>(nullable: true),
                    Ivertinimas = table.Column<int>(nullable: false),
                    Ilgis = table.Column<float>(nullable: false),
                    KlientasId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marsrutas", x => x.MarsrutasId);
                    table.ForeignKey(
                        name: "FK_Marsrutas_Klientas_KlientasId",
                        column: x => x.KlientasId,
                        principalTable: "Klientas",
                        principalColumn: "KlientasId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MokejimoKortele",
                columns: table => new
                {
                    MokejimoKorteleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Numeris = table.Column<string>(nullable: true),
                    Savininkas = table.Column<string>(nullable: true),
                    KlientasId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MokejimoKortele", x => x.MokejimoKorteleId);
                    table.ForeignKey(
                        name: "FK_MokejimoKortele_Klientas_KlientasId",
                        column: x => x.KlientasId,
                        principalTable: "Klientas",
                        principalColumn: "KlientasId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KlientoPasiekimai",
                columns: table => new
                {
                    KlientoPasiekimaiId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    KlientasId = table.Column<int>(nullable: false),
                    PasiekimasId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KlientoPasiekimai", x => x.KlientoPasiekimaiId);
                    table.ForeignKey(
                        name: "FK_KlientoPasiekimai_Klientas_KlientasId",
                        column: x => x.KlientasId,
                        principalTable: "Klientas",
                        principalColumn: "KlientasId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KlientoPasiekimai_Pasiekimas_PasiekimasId",
                        column: x => x.PasiekimasId,
                        principalTable: "Pasiekimas",
                        principalColumn: "PasiekimasId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dviratis",
                columns: table => new
                {
                    DviratisId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Busena = table.Column<int>(nullable: false),
                    Gamintojas = table.Column<string>(nullable: true),
                    Tipas = table.Column<string>(nullable: true),
                    nuomosKaina = table.Column<float>(nullable: false),
                    AiksteleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dviratis", x => x.DviratisId);
                    table.ForeignKey(
                        name: "FK_Dviratis_Aikstele_AiksteleId",
                        column: x => x.AiksteleId,
                        principalTable: "Aikstele",
                        principalColumn: "AiksteleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Taskas",
                columns: table => new
                {
                    TaskasId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Longtitude = table.Column<float>(nullable: false),
                    Latitude = table.Column<float>(nullable: false),
                    MarsrutasId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taskas", x => x.TaskasId);
                    table.ForeignKey(
                        name: "FK_Taskas_Marsrutas_MarsrutasId",
                        column: x => x.MarsrutasId,
                        principalTable: "Marsrutas",
                        principalColumn: "MarsrutasId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Gedimas",
                columns: table => new
                {
                    GedimasId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    registravimoLaikas = table.Column<DateTime>(nullable: false),
                    Apibudinimas = table.Column<string>(nullable: true),
                    DviratisId = table.Column<int>(nullable: false),
                    KlientasId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gedimas", x => x.GedimasId);
                    table.ForeignKey(
                        name: "FK_Gedimas_Dviratis_DviratisId",
                        column: x => x.DviratisId,
                        principalTable: "Dviratis",
                        principalColumn: "DviratisId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Gedimas_Klientas_KlientasId",
                        column: x => x.KlientasId,
                        principalTable: "Klientas",
                        principalColumn: "KlientasId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kelione",
                columns: table => new
                {
                    KelioneId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    kelionesPradzia = table.Column<DateTime>(nullable: false),
                    kelionesPabaiga = table.Column<DateTime>(nullable: false),
                    nuvaziuotasAtstumas = table.Column<float>(nullable: false),
                    kelionesTrukme = table.Column<float>(nullable: false),
                    pradziosAdresas = table.Column<string>(nullable: true),
                    pabaigosAdresas = table.Column<string>(nullable: true),
                    DviratisId = table.Column<int>(nullable: false),
                    ApmokejimasId = table.Column<int>(nullable: false),
                    KlientasId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kelione", x => x.KelioneId);
                    table.ForeignKey(
                        name: "FK_Kelione_Apmokejimas_ApmokejimasId",
                        column: x => x.ApmokejimasId,
                        principalTable: "Apmokejimas",
                        principalColumn: "ApmokejimasId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kelione_Dviratis_DviratisId",
                        column: x => x.DviratisId,
                        principalTable: "Dviratis",
                        principalColumn: "DviratisId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kelione_Klientas_KlientasId",
                        column: x => x.KlientasId,
                        principalTable: "Klientas",
                        principalColumn: "KlientasId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aikstele_DarbuotojasId",
                table: "Aikstele",
                column: "DarbuotojasId");

            migrationBuilder.CreateIndex(
                name: "IX_Dviratis_AiksteleId",
                table: "Dviratis",
                column: "AiksteleId");

            migrationBuilder.CreateIndex(
                name: "IX_Gedimas_DviratisId",
                table: "Gedimas",
                column: "DviratisId");

            migrationBuilder.CreateIndex(
                name: "IX_Gedimas_KlientasId",
                table: "Gedimas",
                column: "KlientasId");

            migrationBuilder.CreateIndex(
                name: "IX_Iskvietimas_DarbuotojasId",
                table: "Iskvietimas",
                column: "DarbuotojasId");

            migrationBuilder.CreateIndex(
                name: "IX_Iskvietimas_KlientasId",
                table: "Iskvietimas",
                column: "KlientasId");

            migrationBuilder.CreateIndex(
                name: "IX_Kelione_ApmokejimasId",
                table: "Kelione",
                column: "ApmokejimasId");

            migrationBuilder.CreateIndex(
                name: "IX_Kelione_DviratisId",
                table: "Kelione",
                column: "DviratisId");

            migrationBuilder.CreateIndex(
                name: "IX_Kelione_KlientasId",
                table: "Kelione",
                column: "KlientasId");

            migrationBuilder.CreateIndex(
                name: "IX_KlientoPasiekimai_KlientasId",
                table: "KlientoPasiekimai",
                column: "KlientasId");

            migrationBuilder.CreateIndex(
                name: "IX_KlientoPasiekimai_PasiekimasId",
                table: "KlientoPasiekimai",
                column: "PasiekimasId");

            migrationBuilder.CreateIndex(
                name: "IX_Marsrutas_KlientasId",
                table: "Marsrutas",
                column: "KlientasId");

            migrationBuilder.CreateIndex(
                name: "IX_MokejimoKortele_KlientasId",
                table: "MokejimoKortele",
                column: "KlientasId");

            migrationBuilder.CreateIndex(
                name: "IX_Taskas_MarsrutasId",
                table: "Taskas",
                column: "MarsrutasId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gedimas");

            migrationBuilder.DropTable(
                name: "Iskvietimas");

            migrationBuilder.DropTable(
                name: "Kelione");

            migrationBuilder.DropTable(
                name: "KlientoPasiekimai");

            migrationBuilder.DropTable(
                name: "MokejimoKortele");

            migrationBuilder.DropTable(
                name: "Taskas");

            migrationBuilder.DropTable(
                name: "Apmokejimas");

            migrationBuilder.DropTable(
                name: "Dviratis");

            migrationBuilder.DropTable(
                name: "Pasiekimas");

            migrationBuilder.DropTable(
                name: "Marsrutas");

            migrationBuilder.DropTable(
                name: "Aikstele");

            migrationBuilder.DropTable(
                name: "Klientas");

            migrationBuilder.DropTable(
                name: "Darbuotojas");
        }
    }
}
