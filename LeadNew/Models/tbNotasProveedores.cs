using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LeadNew.Models
{
    public class tbNotasProveedores
    {
        [Key]
        public int npId { get; set; }
        public int npIdproveedor { get; set; }
        public string npNota { get; set; }
        public System.DateTime npFechaCreacion { get; set; }
    }
}
