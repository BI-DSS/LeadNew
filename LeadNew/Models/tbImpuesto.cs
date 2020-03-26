using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LeadNew.Models
{
    public class tbImpuesto
    {
        [Key]
        public int impId { get; set; }
        public int impIdEmpresa { get; set; }
        public int impPorcentaje { get; set; }
        public string impTipoImpuesto { get; set; }



    }
}
