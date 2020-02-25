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
        public DbSet<LeadNew.Models.tbSucursales> tbSucursales { get; set; }
        public DbSet<LeadNew.Models.tbPaises> tbPaises { get; set; }
        public DbSet<LeadNew.Models.tbRegistroTrubutario> tbRegistroTrubutarios { get; set; }
        public DbSet<LeadNew.Models.tbVendedores> tbVendedores { get; set; }
        public DbSet<LeadNew.Models.tbUsuarios> tbUsuarios { get; set; }

    }

}
