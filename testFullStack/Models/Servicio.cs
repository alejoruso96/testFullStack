using System.ComponentModel.DataAnnotations.Schema;

namespace testFullStack.Models
{
    public class Servicio
    {
        [Column("id_servicio")]
        public int Id { get; set; }

        [Column("nombre_servicio")]
        public string? Nombre { get; set; }

        [Column("descripcion_servicio")]
        public string? Descripcion { get; set; }
    }
}
