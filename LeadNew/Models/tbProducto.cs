using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LeadNew.Models
{
    public class tbProducto
    {
        [Key]
        public int prId { get; set; }
        public string prIdInterno { get; set; }
        public string prDetalle { get; set; }
        public int prCantidad { get; set; }
        public decimal prPrecioCosto { get; set; }
        public decimal prPrecioVenta { get; set; }
        public int prMoneda { get; set; }
        public int prEstado { get; set; }
        public System.DateTime prFechaIngreso { get; set; }
        public string prUsuario { get; set; }
        public int prIdSucursal { get; set; }
        public string img { get; set; }
        public byte[] prImagen { get; set; }

        //public virtual tbSucursales tbSucursales { get; set; }
    }
}
