using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Motyvuoti_Dviratininkai.Models
{
    public class Taskas
    {
        [Key]
        public int TaskasId { get; set; }

        public float Longtitude { get; set; }

        public float Latitude { get; set; }

        public int MarsrutasId { get; set; }

        public virtual Marsrutas Marsrutas { get; set; }
    }
}
