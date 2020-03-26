using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LeadNew.Models
{
    public class tbTipoProveedores
    {
        [Key]
        public int tpId { get; set; }
        public string tpDescripcion { get; set; }
        public System.DateTime tpFechaCreacion { get; set; }
    }
}
