using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeadNew.Models
{
    public class tbEmpresa
    {
        [Key]
        public int empId { get; set; }
        public string empNombre { get; set; }
        public string empDireccion { get; set; }
        public string empTelefono { get; set; }
        public string empLogo { get; set; }
        public int empPais { get; set; }
        public int empMoneda { get; set; }
        public int empLenguaje { get; set; }
        public int empLicencia { get; set; }
        public int empCantidadUser { get; set; }
        public int empUsuarioCrea { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime empFechaCrea { get; set; }
        public int empUsuarioModifica { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime empFechaModifica { get; set; }
    }
}
