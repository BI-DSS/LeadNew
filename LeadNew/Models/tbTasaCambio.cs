using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LeadNew.Models
{
    public class tbTasaCambio
    {
        [Key]
        public int id { get; set; }
        public string tcDescripcion { get; set; }
        public System.DateTime tcFechaIngreso { get; set; }
        public int tcEstado { get; set; }
        public decimal tcValor { get; set; }
    }
}
