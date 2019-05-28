using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Motyvuoti_Dviratininkai.Models
{
    public class MokejimoKortele
    {
        [Key]
        public int MokejimoKorteleId { get; set; }

        public string Numeris { get; set; }

        public string Savininkas { get; set; }

        public int KlientasId { get; set; }

        public virtual Klientas Klientas { get; set; }
    }
}
