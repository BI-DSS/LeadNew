using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LeadNew.Models
{
    public class tbCategoriaProducto
    {
        [Key]
        public int catId { get; set; }
        public string catNombre { get; set; }
        public string catDescripcion { get; set; }
        public System.DateTime catFechaCreacion { get; set; }
    }
}
