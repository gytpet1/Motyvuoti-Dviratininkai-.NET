using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Motyvuoti_Dviratininkai.Models
{
    public class Dviratis
    {
        [Key]
        public int DviratisId { get; set; }
       

        public string Gamintojas { get; set; }

        public string Tipas { get; set; }

        public float nuomosKaina { get; set; }

        public int DviracioBusenaId { get; set; }

        public DviracioBusena Busena { get; set; }

        public int AiksteleId { get; set; }

        public virtual Aikstele Aikstele { get; set; }

        public virtual ICollection<Kelione> Keliones { get; set; }

        public virtual ICollection<Gedimas> Gedimai { get; set; }
    }

}
