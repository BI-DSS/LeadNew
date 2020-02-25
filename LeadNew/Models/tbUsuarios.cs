using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LeadNew.Models
{
    public class tbUsuarios
    {
        [Key]
        public int usuId { get; set; }
        public string usuNombreUsuario { get; set; }
        public string usuPassword { get; set; }
        public string usuNombres { get; set; }
        public string usuApellidos { get; set; }
        public string usuCorreo { get; set; }
        public int usuEsActivo { get; set; }
        public string usuRazonInactivo { get; set; }
        public int usuIdEmpresa { get; set; }
        public int usuIdSucursal { get; set; }



    }
}
