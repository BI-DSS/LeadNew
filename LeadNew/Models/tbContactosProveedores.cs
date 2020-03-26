using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LeadNew.Models
{
    public class tbContactosProveedores
    {
        [Key]
        public int cpId { get; set; }
        public int cpIdproveedor { get; set; }
        public string cpNombre { get; set; }
        public string cpCorreo { get; set; }
        public string cpTelefono { get; set; }
        public string cpPuesto { get; set; }
        public System.DateTime cpFechaCreacion { get; set; }
    }
}
