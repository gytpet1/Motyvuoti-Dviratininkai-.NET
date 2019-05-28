using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Motyvuoti_Dviratininkai.Models
{
    public class KlientoPasiekimai
    {
        [Key]
        public int KlientoPasiekimaiId { get; set; }

        public int KlientasId { get; set; }

        public virtual Klientas Klientas { get; set; }

        public int PasiekimasId { get; set; }

        public virtual Pasiekimas Pasiekimas { get; set; }
    }
}
