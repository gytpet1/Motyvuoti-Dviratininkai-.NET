using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Motyvuoti_Dviratininkai.Models
{
    public class Klientas
    {
        [Key]
        public int KlientasId { get; set; }

        public string elPastas { get; set; }

        public string Slaptazodis { get; set; }

        public string telNumeris { get; set; }

        public string Pavarde { get; set; }

        public string Vardas { get; set; }



        public virtual ICollection<Kelione> Keliones { get; set; }

        public virtual ICollection<KlientoPasiekimai> KlientoPasiekimai { get; set; }

        public virtual ICollection<Gedimas> Gedimai { get; set; }

        public virtual ICollection<Marsrutas> Marsrutai { get; set; }

        public virtual ICollection<Iskvietimas> Iskvietimai { get; set; }
    }
}
