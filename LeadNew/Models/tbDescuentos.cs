using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LeadNew.Models
{
    public class tbDescuentos
    {
        [Key]
        public int desId { get; set; }
        public string desNombreCampaña { get; set; }
        public int desPorcentaje { get; set; }
        public System.DateTime desFechaCreacion { get; set; }
        public System.DateTime desFechaInicio { get; set; }
        public System.DateTime desFechaFinal { get; set; }
        public int desIdProducto { get; set; }
    }
}
