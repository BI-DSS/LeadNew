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

        [StringLength(50, ErrorMessage = "Longitud máxima 50", MinimumLength = 6)]
        public string sucNombre { get; set; }

        [StringLength(50, ErrorMessage = "Longitud máxima 50", MinimumLength = 6)]
        public int sucIdEmpresa { get; set; }

        public System.DateTime sucFechaCreacion { get; set; }

        public int sucEstado { get; set; }
    }
}
    

    
