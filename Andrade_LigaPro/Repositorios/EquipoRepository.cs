using Andrade_LigaPro.Models;

namespace Andrade_LigaPro.Repositorios
{
    public class EquipoRepository
    {

        public IEnumerable<equipo> Equipos;

        public EquipoRepository()
        {
            Equipos = DevuelveListadoEquipo();
        }
        public IEnumerable<equipo> DevuelveListadoEquipo()
        {
            List<equipo> equipos = new List<equipo>();

            equipo ldu = new equipo
            {
                Id = 1,
                Nombre = "Liga de Quito",
                partidosEmpatados = 2,
                partidosGanados = 3,
                partidosJugados = 6,
                partidosPerdidos = 1

            };
            equipos.Add(ldu);
            equipo bsc = new equipo
            {
                Id = 2,
                Nombre = "Barcelona Sporting Club",
                partidosEmpatados = 0,
                partidosGanados = 5,
                partidosJugados = 6,
                partidosPerdidos = 1

            };
            equipos.Add(bsc);

            equipo uCat = new equipo
            {
                Id = 3,
                Nombre = "Universidad Catolica",
                partidosEmpatados = 3,
                partidosGanados = 3,
                partidosJugados = 7,
                partidosPerdidos = 1

            };
            equipos.Add(uCat);

            equipo idv = new equipo
            {
                Id = 4,
                Nombre = "Independiente del Valle",
                partidosEmpatados = 3,
                partidosGanados = 3,
                partidosJugados = 7,
                partidosPerdidos = 1

            };
            equipos.Add(idv);

            equipo cun = new equipo
            {
                Id = 5,
                Nombre = "Cuniburo Futbol Club",
                partidosEmpatados = 3,
                partidosGanados = 3,
                partidosJugados = 7,
                partidosPerdidos = 1

            };
            equipos.Add(cun);

            equipo lib = new equipo
            {
                Id = 6,
                Nombre = "Libertad Futbol Club",
                partidosEmpatados = 2,
                partidosGanados = 3,
                partidosJugados = 7,
                partidosPerdidos = 2

            };
            equipos.Add(lib);

            equipo ore = new equipo
            {
                Id = 7,
                Nombre = "Orense",
                partidosEmpatados = 1,
                partidosGanados = 3,
                partidosJugados = 7,
                partidosPerdidos = 3

            };
            equipos.Add(ore);

            equipo mus = new equipo
            {
                Id = 8,
                Nombre = "Mushuc Runa",
                partidosEmpatados = 3,
                partidosGanados = 2,
                partidosJugados = 7,
                partidosPerdidos = 2

            };
            equipos.Add(mus);

            equipo auc = new equipo
            {
                Id = 9,
                Nombre = "Aucas",
                partidosEmpatados = 3,
                partidosGanados = 2,
                partidosJugados = 7,
                partidosPerdidos = 2

            };
            equipos.Add(auc);

            equipo mac = new equipo
            {
                Id = 10,
                Nombre = "Macara",
                partidosEmpatados = 3,
                partidosGanados = 2,
                partidosJugados = 7,
                partidosPerdidos = 2

            };
            equipos.Add(mac);

            equipo cue = new equipo
            {
                Id = 11,
                Nombre = "Deportivo Cuenca",
                partidosEmpatados = 1,
                partidosGanados = 2,
                partidosJugados = 7,
                partidosPerdidos = 4

            };
            equipos.Add(cue);

            equipo man = new equipo
            {
                Id = 12,
                Nombre = "Manta",
                partidosEmpatados = 3,
                partidosGanados = 1,
                partidosJugados = 7,
                partidosPerdidos = 3

            };
            equipos.Add(man);

            equipo tec = new equipo
            {
                Id = 13,
                Nombre = "Tecnico Universitario",
                partidosEmpatados = 3,
                partidosGanados = 1,
                partidosJugados = 7,
                partidosPerdidos = 3

            };
            equipos.Add(tec);

            equipo del = new equipo
            {
                Id = 14,
                Nombre = "Delfin",
                partidosEmpatados = 3,
                partidosGanados = 1,
                partidosJugados = 7,
                partidosPerdidos = 3

            };
            equipos.Add(del);

            equipo eme = new equipo
            {
                Id = 15,
                Nombre = "Emelec",
                partidosEmpatados = 3,
                partidosGanados = 1,
                partidosJugados = 7,
                partidosPerdidos = 3 

            };
            equipos.Add(eme);

            equipo nac = new equipo
            {
                Id = 16,
                Nombre = "El Nacional",
                partidosEmpatados = 2,
                partidosGanados = 1,
                partidosJugados = 7,
                partidosPerdidos = 4

            };
            equipos.Add(nac);









            return equipos;
        }

        public equipo DevuelveEquipoPorID(int Id)
        {
            
            var Equipo = Equipos.First(item=> item.Id == Id); //Devuelve el primer elemento que encuentre con ese ID

            return Equipo;
        }

        public bool ActualizarEquipo(int Id, equipo Equipo)
        {
            //logic
            return true;
        }

    }
}
