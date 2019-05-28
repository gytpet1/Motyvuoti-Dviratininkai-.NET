using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Motyvuoti_Dviratininkai.Models;

namespace Motyvuoti_Dviratininkai.Models
{
    public class Motyvuoti_DviratininkaiContext : DbContext
    {
        public Motyvuoti_DviratininkaiContext (DbContextOptions<Motyvuoti_DviratininkaiContext> options)
            : base(options)
        {
        }

        public DbSet<Motyvuoti_Dviratininkai.Models.Aikstele> Aikstele { get; set; }

        public DbSet<Motyvuoti_Dviratininkai.Models.Apmokejimas> Apmokejimas { get; set; }

        public DbSet<Motyvuoti_Dviratininkai.Models.Darbuotojas> Darbuotojas { get; set; }

        public DbSet<Motyvuoti_Dviratininkai.Models.Dviratis> Dviratis { get; set; }

        public DbSet<Motyvuoti_Dviratininkai.Models.Gedimas> Gedimas { get; set; }

        public DbSet<Motyvuoti_Dviratininkai.Models.Iskvietimas> Iskvietimas { get; set; }

        public DbSet<Motyvuoti_Dviratininkai.Models.Kelione> Kelione { get; set; }

        public DbSet<Motyvuoti_Dviratininkai.Models.Klientas> Klientas { get; set; }

        public DbSet<Motyvuoti_Dviratininkai.Models.KlientoPasiekimai> KlientoPasiekimai { get; set; }

        public DbSet<Motyvuoti_Dviratininkai.Models.Marsrutas> Marsrutas { get; set; }

        public DbSet<Motyvuoti_Dviratininkai.Models.MokejimoKortele> MokejimoKortele { get; set; }

        public DbSet<Motyvuoti_Dviratininkai.Models.Pasiekimas> Pasiekimas { get; set; }

        public DbSet<Motyvuoti_Dviratininkai.Models.Taskas> Taskas { get; set; }

        public DbSet<Motyvuoti_Dviratininkai.Models.DviracioBusena> DviracioBusena { get; set; }
    }
}
