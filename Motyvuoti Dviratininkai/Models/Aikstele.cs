using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Motyvuoti_Dviratininkai.Models
{
    public class Aikstele
    {
            [Key]
            public int AiksteleId { get; set; }

            public string Adresas { get; set; }

            public int vietuSkaicius { get; set; }

            public int laisvuVietuSkacius { get; set; }

            public float Latitude { get; set; }

            public float Longtitude { get; set; }

            public virtual ICollection<Dviratis> Dviraciai { get; set; }

            public int DarbuotojasId { get; set; }

            public virtual Darbuotojas Darbuotojas { get; set; }
    }
}
