using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Motyvuoti_Dviratininkai.Models
{
    public class Darbuotojas
    {
        [Key]
        public int DarbuotojasId { get; set; }

        public string Vardas { get; set; }

        public string elPastas { get; set; }

        public string Slaptazodis { get; set; }

        public string Pavarde { get; set; }

        public string tabelioNr { get; set; }

        public string Pareigos { get; set; }

        public virtual ICollection<Aikstele> Aiksteles { get; set; }
    }
}
