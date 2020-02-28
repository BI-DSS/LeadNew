using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LeadNew.Models
{
    public class tbRegistroTributario
    {
        [Key]
        public int rtId { get; set; }
        public int rtIdEmpresa { get; set; }
        public string rtCAI { get; set; }
        public DateTime rtFechaCreacion { get; set; }
        public DateTime rtFechainicio { get; set; }
        public DateTime rtFechafinal { get; set; }
        public string rtRangoAutoInicio { get; set; }
        public string rtRangoAutoFinal { get; set; }
    }
}
