using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using VentaProducto.Server.Models.PruebaVentas;

namespace VentaProducto.Server.Data
{
    public partial class PruebaVentasContext : DbContext
    {
        public PruebaVentasContext()
        {
        }

        public PruebaVentasContext(DbContextOptions<PruebaVentasContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<VentaProducto.Server.Models.PruebaVentas.IiN04> IiN04S { get; set; }

        public DbSet<VentaProducto.Server.Models.PruebaVentas.IN05> IN05S { get; set; }
    }
}