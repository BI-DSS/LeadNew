using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LeadNew.Models
{
    public class tbTipoLicencia
    {
        [Key]
        public int tlicId { get; set; }
        public string tlicDescripcion { get; set; }
        public int tlicUsuarioCrea { get; set; }
        public System.DateTime tlicFechaCrea { get; set; }
        public Nullable<int> tlicUsuarioModifica { get; set; }
        public Nullable<System.DateTime> tlicFechaModifica { get; set; }
    }
}
