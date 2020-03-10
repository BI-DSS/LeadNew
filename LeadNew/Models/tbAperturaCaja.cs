using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LeadNew.Models
{
    public class tbAperturaCaja
    {
        [Key]
        public int acId { get; set; }
        public decimal acValorApertura { get; set; }
        public int acEstado { get; set; }
        public int acIdUsuario { get; set; }
        public DateTime acFechaApertura { get; set; }
    }
}
