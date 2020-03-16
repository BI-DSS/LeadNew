using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LeadNew.Models
{
    public class tbCierreCaja
    {
        [Key]
        public int ccId { get; set; }
        public decimal ccTotalCierre { get; set; }
        public int ccIdEmpresa { get; set; }
        public int ccIdSucursal { get; set; }
        public int ccIdUsuario { get; set; }
        public DateTime ccFechaCierre { get; set; }
    }
}
