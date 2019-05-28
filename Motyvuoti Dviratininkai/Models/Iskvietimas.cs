using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Motyvuoti_Dviratininkai.Models
{
    public class Iskvietimas
    {
        [Key]
        public int IskvietimasId { get; set; }

        public string Apibudinimas { get; set; }

        public int KlientasId { get; set; }

        public virtual Klientas Klientas { get; set; }

        public int DarbuotojasId { get; set; }

        public virtual Darbuotojas Darbuotojas { get; set; }
    }
}
