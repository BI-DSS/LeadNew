using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LeadNew.Models
{
    public class tbClientes
    {
        [Key]
        public int clId { get; set; }
        public string clNombre { get; set; }
        public string clApellido { get; set; }
        public string clTelefono { get; set; }
        public string clIdentidad { get; set; }
        public string clRTN { get; set; }
        public string clDireccion { get; set; }
        public int clUsuarioCrea { get; set; }
        public System.DateTime clFechaCrea { get; set; }
        public int clIdEmpresa { get; set; }
    }
}
