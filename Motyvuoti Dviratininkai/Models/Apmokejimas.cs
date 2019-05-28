using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Motyvuoti_Dviratininkai.Models
{
    public class Apmokejimas
    {
        [Key]
        public int ApmokejimasId { get; set; }



        public DateTime Data { get; set; }


        public double Suma { get; set; }

        public bool arApmoketas { get; set; }

        public int KelioneId { get; set; }

        public virtual Kelione Kelione { get; set; }

    }
}
