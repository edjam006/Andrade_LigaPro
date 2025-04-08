using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Andrade_LigaPro.Models
{
    public class equipo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        [DisplayName("Nombre del equipo")]
        public String Nombre { get; set; }
        [Range(0,100)]
        public int partidosGanados { get; set; }
        [Range(0, 100)]
        public int partidosJugados { get; set; }
        [Range(0, 100)]
        public int partidosPerdidos { get; set; }
        [Range(0, 100)]
        public int partidosEmpatados { get; set; }


        public int Puntos //Esta propiedad ayuda a calcular los puntos
        {
            get
            {
                return (partidosGanados * 3) + (partidosEmpatados * 1);
            }
        }

            

    }
}
