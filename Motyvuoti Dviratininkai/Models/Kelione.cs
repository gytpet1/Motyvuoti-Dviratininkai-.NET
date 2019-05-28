using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Motyvuoti_Dviratininkai.Models
{
    public class Kelione
    {
        [Key]
        public int KelioneId { get; set; }


        public DateTime kelionesPradzia { get; set; }

        public DateTime kelionesPabaiga { get; set; }

        public float nuvaziuotasAtstumas { get; set; }

        public float kelionesTrukme { get; set; }

        public string pradziosAdresas { get; set; }

        public string pabaigosAdresas { get; set; }

        public int DviratisId { get; set; }

        public virtual Dviratis Dviratis { get; set; }

        public int KlientasId { get; set; }

        public virtual Klientas Klientas { get; set; }
    }
}
