using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LeadNew.Models
{
    public class tbProductoFactura
    {
        //productos
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
        //public string img { get; set; }
        public byte[] prImagen { get; set; }
        public int prIdImpuesto { get; set; }

        //tasa de cambios
        public int idTasaCambio { get; set; }
        public string tcDescripcion { get; set; }
        public System.DateTime tcFechaIngreso { get; set; }
        public int tcEstado { get; set; }
        public decimal tcValor { get; set; }

        //Monedas
        public int moId { get; set; }
        public string moAbreviatura { get; set; }
        public string moNombre { get; set; }
        public Nullable<int> moUsuarioCrea { get; set; }
        public Nullable<System.DateTime> moFechaCrea { get; set; }
        public Nullable<int> moUsuarioModifica { get; set; }
        public Nullable<System.DateTime> moFechaModifica { get; set; }

        //Descuentos
        public int desId { get; set; }
        public string desNombreCampaña { get; set; }
        public int desPorcentaje { get; set; }
        public System.DateTime desFechaCreacion { get; set; }
        public System.DateTime desFechaInicio { get; set; }
        public System.DateTime desFechaFinal { get; set; }
        public int desIdProducto { get; set; }

        //Impuestos
        public int impId { get; set; }
        public int impIdEmpresa { get; set; }
        public int impPorcentaje { get; set; }
        public string impTipoImpuesto { get; set; }
    }
}
