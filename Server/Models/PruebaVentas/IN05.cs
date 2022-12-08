using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace VentaProducto.Server.Models.PruebaVentas
{
    [Table("IN05", Schema = "dbo")]
    public partial class IN05
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idIN05 { get; set; }

        [Required]
        public int IDFamilia { get; set; }

        [Required]
        public string NombreFamilia { get; set; }

        [Required]
        public string UsuarioIngreso { get; set; }

        public int? Estado { get; set; }

    }
}