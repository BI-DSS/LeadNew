using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LeadNew.Models
{
    public class tbMoneda
    {
        [Key]
        public int moId { get; set; }
        public string moAbreviatura { get; set; }
        public string moNombre { get; set; }
        public Nullable<int> moUsuarioCrea { get; set; }
        public Nullable<System.DateTime> moFechaCrea { get; set; }
        public Nullable<int> moUsuarioModifica { get; set; }
        public Nullable<System.DateTime> moFechaModifica { get; set; }
    }
}
