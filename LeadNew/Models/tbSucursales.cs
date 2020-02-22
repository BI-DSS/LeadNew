using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LeadNew.Models
{
    public class tbSucursales
    {
        [Key]
        public int sucId { get; set; }
        public string sucNombre { get; set; }
        public int sucIdEmpresa { get; set; }
        public System.DateTime sucFechaCreacion { get; set; }
        public int sucEstado { get; set; }
    }
}
    

    
