using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LeadNew.Models
{
    public class tbVendedores
    {
        [Key]
        public int venId { get; set; }
        public string venNombre { get; set; }
        public int venTuId { get; set; }
        public int venEstado { get; set; }
    }
}
