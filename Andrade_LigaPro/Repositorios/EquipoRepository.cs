using Andrade_LigaPro.Models;

namespace Andrade_LigaPro.Repositorios
{
    public class EquipoRepository
    {
        public IEnumerable<equipo> DevuelveListadoEquipo()
        {
            List<equipo> equipos = new List<equipo>();

            equipo ldu = new equipo
            {
                Id = 1,
                Nombre = "Liga de Quito",
                partidosEmpatados = 0,
                partidosGanados = 10,
                partidosJugados = 10,
                partidosPerdidos = 0

            };
            equipos.Add(ldu);
            equipo bsc = new equipo
            {
                Id = 2,
                Nombre = "Barcelona Sporting Club",
                partidosEmpatados = 0,
                partidosGanados = 9,
                partidosJugados = 10,
                partidosPerdidos = 1

            };
            equipos.Add(bsc);
            return equipos;
        }

    }
}
