using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Andrade_LigaPro.Models
{
    [Table("Jugador")]
    public class Jugador
    {
        [Key]
        public int Id { get; set; }

        public string Nombre { get; set; }

        public int NumeroCamiseta { get; set; }

        public int Goles { get; set; }

        public int Asistencias { get; set; }

        public decimal Sueldo { get; set; }

        public int EquipoId { get; set; }

        [ForeignKey("EquipoId")]
        public equipo? Equipo { get; set; }
    }
}
