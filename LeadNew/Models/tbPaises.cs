using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LeadNew.Models
{
    public class tbPaises
    {
        [Key]
        public int paId { get; set; }
        public string paNombre { get; set; }
        public int paCodPostal { get; set; }
        public string paAbreviatura { get; set; }
        public int paUsuarioCrea { get; set; }
        public System.DateTime paFechaCrea { get; set; }
        public Nullable<int> paUsuarioModifica { get; set; }
        public Nullable<System.DateTime> paFechaModifica { get; set; }
    }
}
