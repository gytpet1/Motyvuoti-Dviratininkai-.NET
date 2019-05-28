using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Motyvuoti_Dviratininkai.Models
{
    public class Marsrutas
    {
        [Key]
        public int MarsrutasId { get; set; }

        public string Pavadinimas { get; set; }

        public string Kategorija { get; set; }

        public string Miestas { get; set; }

        public int Ivertinimas { get; set; }

        public float Ilgis { get; set; }

        public virtual ICollection<Taskas> Taskai { get; set; }

        public int KlientasId { get; set; }

        public virtual Klientas Klientas { get; set; }
    }
}
