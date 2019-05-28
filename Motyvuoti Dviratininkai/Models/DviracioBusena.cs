using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Motyvuoti_Dviratininkai.Models
{
    public class DviracioBusena
    {
        [Key]
        public int DviracioBusenaId { get; set; }

        public string Busena { get; set; }
    }
}
