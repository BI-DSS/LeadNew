using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LeadNew.Models
{
    public class tbEmpresa
    {
        [Key]
        public int empId { get; set; }
        public string empNombre { get; set; }
        public string empDireccion { get; set; }
        public string empTelefono { get; set; }
        public byte[] empLogo { get; set; }
        public int empPais { get; set; }
        public int empMoneda { get; set; }
        public int empLenguaje { get; set; }
        public int empLicencia { get; set; }
        public int empCantidadUser { get; set; }
        public int empUsuarioCrea { get; set; }
        public DateTime empFechaCrea { get; set; }
        public int empUsuarioModifica { get; set; }
        public DateTime empFechaModifica { get; set; }
        public int empVenId { get; set; }
        public int emptuId { get; set; }
    }
}
