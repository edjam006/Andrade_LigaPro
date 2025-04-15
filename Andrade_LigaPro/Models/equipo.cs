using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Andrade_LigaPro.Models
{
    public class equipo
    {
        [Key]
        [Display(Name = "")]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        [DisplayName("Nombre del equipo")]
        public String Nombre { get; set; }
        [Range(0,100)]
        [Display(Name = "Partidos Ganados")]
        public int partidosGanados { get; set; }
        [Range(0, 100)]
        [Display(Name = "Partidos Jugados")]
        public int partidosJugados { get; set; }
        [Range(0, 100)]
        [Display(Name = "Partidos Perdidos")]
        public int partidosPerdidos { get; set; }
        [Range(0, 100)]

        [Display(Name = "Partidos Empatados")]
        public int partidosEmpatados { get; set; }

        public String descripcion { get; set; }

        [Display(Name = "Logo del Equipo")]
        public String logo { get; set; }


        public int Puntos //Esta propiedad ayuda a calcular los puntos
        {
            get
            {
                return (partidosGanados * 3) + (partidosEmpatados * 1);
            }
        }

            

    }
}
