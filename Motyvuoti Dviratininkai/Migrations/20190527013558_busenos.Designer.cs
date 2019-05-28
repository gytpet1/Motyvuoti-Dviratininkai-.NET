﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Motyvuoti_Dviratininkai.Models;

namespace Motyvuoti_Dviratininkai.Migrations
{
    [DbContext(typeof(Motyvuoti_DviratininkaiContext))]
    [Migration("20190527013558_busenos")]
    partial class busenos
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Motyvuoti_Dviratininkai.Models.Aikstele", b =>
                {
                    b.Property<int>("AiksteleId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DarbuotojasId");

                    b.Property<float>("Latitude");

                    b.Property<float>("Longtitude");

                    b.Property<int>("laisvuVietuSkacius");

                    b.Property<int>("vietuSkaicius");

                    b.HasKey("AiksteleId");

                    b.HasIndex("DarbuotojasId");

                    b.ToTable("Aikstele");
                });

            modelBuilder.Entity("Motyvuoti_Dviratininkai.Models.Apmokejimas", b =>
                {
                    b.Property<int>("ApmokejimasId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Data");

                    b.Property<double>("Suma");

                    b.Property<bool>("arApmoketas");

                    b.HasKey("ApmokejimasId");

                    b.ToTable("Apmokejimas");
                });

            modelBuilder.Entity("Motyvuoti_Dviratininkai.Models.Darbuotojas", b =>
                {
                    b.Property<int>("DarbuotojasId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Pareigos");

                    b.Property<string>("Pavarde");

                    b.Property<string>("Slaptazodis");

                    b.Property<string>("Vardas");

                    b.Property<string>("elPastas");

                    b.Property<string>("tabelioNr");

                    b.HasKey("DarbuotojasId");

                    b.ToTable("Darbuotojas");
                });

            modelBuilder.Entity("Motyvuoti_Dviratininkai.Models.DviracioBusena", b =>
                {
                    b.Property<int>("DviracioBusenaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Busena");

                    b.HasKey("DviracioBusenaId");

                    b.ToTable("DviracioBusena");
                });

            modelBuilder.Entity("Motyvuoti_Dviratininkai.Models.Dviratis", b =>
                {
                    b.Property<int>("DviratisId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AiksteleId");

                    b.Property<int>("DviracioBusenaId");

                    b.Property<string>("Gamintojas");

                    b.Property<string>("Tipas");

                    b.Property<float>("nuomosKaina");

                    b.HasKey("DviratisId");

                    b.HasIndex("AiksteleId");

                    b.HasIndex("DviracioBusenaId");

                    b.ToTable("Dviratis");
                });

            modelBuilder.Entity("Motyvuoti_Dviratininkai.Models.Gedimas", b =>
                {
                    b.Property<int>("GedimasId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apibudinimas");

                    b.Property<int>("DviratisId");

                    b.Property<int>("KlientasId");

                    b.Property<DateTime>("registravimoLaikas");

                    b.HasKey("GedimasId");

                    b.HasIndex("DviratisId");

                    b.HasIndex("KlientasId");

                    b.ToTable("Gedimas");
                });

            modelBuilder.Entity("Motyvuoti_Dviratininkai.Models.Iskvietimas", b =>
                {
                    b.Property<int>("IskvietimasId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apibudinimas");

                    b.Property<int>("DarbuotojasId");

                    b.Property<int>("KlientasId");

                    b.HasKey("IskvietimasId");

                    b.HasIndex("DarbuotojasId");

                    b.HasIndex("KlientasId");

                    b.ToTable("Iskvietimas");
                });

            modelBuilder.Entity("Motyvuoti_Dviratininkai.Models.Kelione", b =>
                {
                    b.Property<int>("KelioneId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ApmokejimasId");

                    b.Property<int>("DviratisId");

                    b.Property<int>("KlientasId");

                    b.Property<DateTime>("kelionesPabaiga");

                    b.Property<DateTime>("kelionesPradzia");

                    b.Property<float>("kelionesTrukme");

                    b.Property<float>("nuvaziuotasAtstumas");

                    b.Property<string>("pabaigosAdresas");

                    b.Property<string>("pradziosAdresas");

                    b.HasKey("KelioneId");

                    b.HasIndex("ApmokejimasId");

                    b.HasIndex("DviratisId");

                    b.HasIndex("KlientasId");

                    b.ToTable("Kelione");
                });

            modelBuilder.Entity("Motyvuoti_Dviratininkai.Models.Klientas", b =>
                {
                    b.Property<int>("KlientasId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Pavarde");

                    b.Property<string>("Slaptazodis");

                    b.Property<string>("Vardas");

                    b.Property<string>("elPastas");

                    b.Property<string>("telNumeris");

                    b.HasKey("KlientasId");

                    b.ToTable("Klientas");
                });

            modelBuilder.Entity("Motyvuoti_Dviratininkai.Models.KlientoPasiekimai", b =>
                {
                    b.Property<int>("KlientoPasiekimaiId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("KlientasId");

                    b.Property<int>("PasiekimasId");

                    b.HasKey("KlientoPasiekimaiId");

                    b.HasIndex("KlientasId");

                    b.HasIndex("PasiekimasId");

                    b.ToTable("KlientoPasiekimai");
                });

            modelBuilder.Entity("Motyvuoti_Dviratininkai.Models.Marsrutas", b =>
                {
                    b.Property<int>("MarsrutasId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Ilgis");

                    b.Property<int>("Ivertinimas");

                    b.Property<string>("Kategorija");

                    b.Property<int>("KlientasId");

                    b.Property<string>("Miestas");

                    b.Property<string>("Pavadinimas");

                    b.HasKey("MarsrutasId");

                    b.HasIndex("KlientasId");

                    b.ToTable("Marsrutas");
                });

            modelBuilder.Entity("Motyvuoti_Dviratininkai.Models.MokejimoKortele", b =>
                {
                    b.Property<int>("MokejimoKorteleId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("KlientasId");

                    b.Property<string>("Numeris");

                    b.Property<string>("Savininkas");

                    b.HasKey("MokejimoKorteleId");

                    b.HasIndex("KlientasId");

                    b.ToTable("MokejimoKortele");
                });

            modelBuilder.Entity("Motyvuoti_Dviratininkai.Models.Pasiekimas", b =>
                {
                    b.Property<int>("PasiekimasId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Kilometrai");

                    b.Property<string>("Pavadinimas");

                    b.HasKey("PasiekimasId");

                    b.ToTable("Pasiekimas");
                });

            modelBuilder.Entity("Motyvuoti_Dviratininkai.Models.Taskas", b =>
                {
                    b.Property<int>("TaskasId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Latitude");

                    b.Property<float>("Longtitude");

                    b.Property<int>("MarsrutasId");

                    b.HasKey("TaskasId");

                    b.HasIndex("MarsrutasId");

                    b.ToTable("Taskas");
                });

            modelBuilder.Entity("Motyvuoti_Dviratininkai.Models.Aikstele", b =>
                {
                    b.HasOne("Motyvuoti_Dviratininkai.Models.Darbuotojas", "Darbuotojas")
                        .WithMany("Aiksteles")
                        .HasForeignKey("DarbuotojasId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Motyvuoti_Dviratininkai.Models.Dviratis", b =>
                {
                    b.HasOne("Motyvuoti_Dviratininkai.Models.Aikstele", "Aikstele")
                        .WithMany("Dviraciai")
                        .HasForeignKey("AiksteleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Motyvuoti_Dviratininkai.Models.DviracioBusena", "Busena")
                        .WithMany()
                        .HasForeignKey("DviracioBusenaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Motyvuoti_Dviratininkai.Models.Gedimas", b =>
                {
                    b.HasOne("Motyvuoti_Dviratininkai.Models.Dviratis", "Dviratis")
                        .WithMany("Gedimai")
                        .HasForeignKey("DviratisId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Motyvuoti_Dviratininkai.Models.Klientas", "Klientas")
                        .WithMany("Gedimai")
                        .HasForeignKey("KlientasId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Motyvuoti_Dviratininkai.Models.Iskvietimas", b =>
                {
                    b.HasOne("Motyvuoti_Dviratininkai.Models.Darbuotojas", "Darbuotojas")
                        .WithMany()
                        .HasForeignKey("DarbuotojasId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Motyvuoti_Dviratininkai.Models.Klientas", "Klientas")
                        .WithMany("Iskvietimai")
                        .HasForeignKey("KlientasId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Motyvuoti_Dviratininkai.Models.Kelione", b =>
                {
                    b.HasOne("Motyvuoti_Dviratininkai.Models.Apmokejimas", "Apmokejimas")
                        .WithMany()
                        .HasForeignKey("ApmokejimasId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Motyvuoti_Dviratininkai.Models.Dviratis", "Dviratis")
                        .WithMany("Keliones")
                        .HasForeignKey("DviratisId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Motyvuoti_Dviratininkai.Models.Klientas", "Klientas")
                        .WithMany("Keliones")
                        .HasForeignKey("KlientasId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Motyvuoti_Dviratininkai.Models.KlientoPasiekimai", b =>
                {
                    b.HasOne("Motyvuoti_Dviratininkai.Models.Klientas", "Klientas")
                        .WithMany("KlientoPasiekimai")
                        .HasForeignKey("KlientasId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Motyvuoti_Dviratininkai.Models.Pasiekimas", "Pasiekimas")
                        .WithMany("KlientoPasiekimai")
                        .HasForeignKey("PasiekimasId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Motyvuoti_Dviratininkai.Models.Marsrutas", b =>
                {
                    b.HasOne("Motyvuoti_Dviratininkai.Models.Klientas", "Klientas")
                        .WithMany("Marsrutai")
                        .HasForeignKey("KlientasId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Motyvuoti_Dviratininkai.Models.MokejimoKortele", b =>
                {
                    b.HasOne("Motyvuoti_Dviratininkai.Models.Klientas", "Klientas")
                        .WithMany()
                        .HasForeignKey("KlientasId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Motyvuoti_Dviratininkai.Models.Taskas", b =>
                {
                    b.HasOne("Motyvuoti_Dviratininkai.Models.Marsrutas", "Marsrutas")
                        .WithMany("Taskai")
                        .HasForeignKey("MarsrutasId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
