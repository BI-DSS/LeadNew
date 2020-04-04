using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LeadNew.Models;

namespace LeadNew.Models
{
    public class LeadNewDB : DbContext
    {
        public LeadNewDB (DbContextOptions<LeadNewDB> options)
            : base(options)
        {
        }
        
        public DbSet<LeadNew.Models.tbMoneda> tbMoneda { get; set; }
        public DbSet<LeadNew.Models.tbLenguaje> tbLenguaje { get; set; }
        public DbSet<LeadNew.Models.tbTasaCambio> tbTasaCambio { get; set; }
        public DbSet<LeadNew.Models.tbClientes> tbClientes { get; set; }
        public DbSet<LeadNew.Models.tbEmpresa> tbEmpresa { get; set; }
        public DbSet<LeadNew.Models.tbProducto> tbProducto { get; set; }
        public DbSet<LeadNew.Models.tbSucursales> tbSucursales { get; set; }
        public DbSet<LeadNew.Models.tbPaises> tbPaises { get; set; }
        public DbSet<LeadNew.Models.tbUsuarios> tbUsuarios { get; set; }
        public DbSet<LeadNew.Models.tbVendedores> tbVendedores { get; set; }
        public DbSet<LeadNew.Models.tbRegistroTributario> tbRegistroTributarios { get; set; }
        public DbSet<LeadNew.Models.tbTipoLicencia> tbTipoLicencia { get; set; }
        public DbSet<LeadNew.Models.tbCategoriaProducto> tbCategoriaProducto { get; set; }
        public DbSet<LeadNew.Models.tbDescuentos> tbDescuentos { get; set; } 
        public DbSet<LeadNew.Models.tbAperturaCaja> tbAperturaCajas { get; set; }

        public DbSet<LeadNew.Models.tbProductoFactura> tbProductoFactura { get; set; }
        public DbSet<LeadNew.Models.tbImpuesto> tbImpuesto { get; set; }        

        public DbSet<LeadNew.Models.tbCierreCaja> tbCierreCajas { get; set; }
        public DbSet<LeadNew.Models.tbRegistroTributario> tbRegistroTributario { get; set; }
        public DbSet<LeadNew.Models.RegistroTributarioNotificaciones> RegistroTributarioNotificaciones { get; set; }
        public DbSet<LeadNew.Models.tbProveedores> tbProveedores { get; set; }
        public DbSet<LeadNew.Models.tbTipoProveedores> tbTipoProveedores { get; set; }
        public DbSet<LeadNew.Models.tbContactosProveedores> tbContactosProveedores { get; set; }
        public DbSet<LeadNew.Models.tbNotasProveedores> tbNotasProveedores { get; set; }
        public DbSet<LeadNew.Models.MonedaVista> MonedaVista { get; set; }
        public DbSet<LeadNew.Models.DescuentosVista> DescuentosVista { get; set; }
        public DbSet<LeadNew.Models.ProductosVista> ProductosVista { get; set; }
        public DbSet<LeadNew.Models.ProveedoresVista> ProveedoresVista { get; set; }        
    }

}
