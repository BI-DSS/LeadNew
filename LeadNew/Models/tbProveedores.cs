using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LeadNew.Models
{
    public class tbProveedores
    {
        [Key]
        public int pvId { get; set; }

        public string pvNombre { get; set; }

        public string pvTelefono { get; set; }
        public string pvCorreo { get; set; }
        public string pvDireccion { get; set; }
        public string pvDescripcion { get; set; }
        public System.DateTime pvFechaCreacion { get; set; }
        public int pvIdTipo { get; set; }
        public string pvSitioWeb { get; set; }
        public byte[] pvImg { get; set; }
        public string tpDescripcion { get; set; }
    }
}
