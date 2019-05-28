using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Motyvuoti_Dviratininkai.Models
{
    public class Pasiekimas
    {
        [Key]
        public int PasiekimasId { get; set; }

        public string Pavadinimas { get; set; }

        public double Kilometrai { get; set; }

        public virtual ICollection<KlientoPasiekimai> KlientoPasiekimai { get; set; }
    }
}
