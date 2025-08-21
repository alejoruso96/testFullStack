using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace testFullStack.Models
{
    public class Cliente
    {
        [Column("id_cliente")]
        [Key]
        public int Id { get; set; }

        [Column("nombre_cliente")]
        public string? Nombre { get; set; }

        [Column("correo_cliente")]
        public string? Correo { get; set; }
    }
}
