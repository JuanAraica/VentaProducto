using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace VentaProducto.Server.Models.PruebaVentas
{
    [Table("IIN04", Schema = "dbo")]
    public partial class IiN04
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        public string CodigoProducto { get; set; }

        [Required]
        public string Descripcion { get; set; }

        public decimal? Precio { get; set; }

        public decimal? SaldoInventario { get; set; }

        public DateTime? FechaIngreso { get; set; }

        public string UsuarioIngreso { get; set; }

        public int? IDFamilia { get; set; }

    }
}