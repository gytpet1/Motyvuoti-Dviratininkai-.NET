using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Motyvuoti_Dviratininkai.Models
{
    public class Gedimas
    {
        [Key]
        public int GedimasId { get; set; }

        public DateTime registravimoLaikas { get; set; }

        public string Apibudinimas { get; set; }

        public int DviratisId { get; set; }

        public virtual Dviratis Dviratis { get; set; }

        public int KlientasId { get; set; }

        public virtual Klientas Klientas { get; set; }
    }
}
