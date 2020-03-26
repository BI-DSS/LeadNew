using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LeadNew.Models
{
    public class tbLenguaje
    {
        [Key]
        public int lenId { get; set; }

        [StringLength(50, ErrorMessage = "Longitud máxima 50", MinimumLength = 6)]
        public string lenNombre { get; set; }

        public System.DateTime lenFehcaActivacion { get; set; }
    }
}
