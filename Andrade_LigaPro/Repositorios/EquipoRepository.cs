using Andrade_LigaPro.Models;
using System.Text.Json;
using System.IO;

namespace Andrade_LigaPro.Repositorios
{
    public class EquipoRepository
    {

        public static List<equipo> Equipos = new List<equipo>();

        public EquipoRepository()
        {
            if (Equipos.Count == 0)
            {
                CargarDesdeJson(); // Carga los datos guardados del JSon si existen
                if (Equipos.Count == 0)
                {
                    Equipos = DevuelveListadoEquipo().ToList(); // Se cargan valores por defecto si el JSON está vacío
                }
            }
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

        public IEnumerable<equipo> DevuelveListadoEquipos()
        {
            return Equipos;
        }

        public equipo DevuelveEquipoPorID(int Id)
        {
            
            var Equipo = Equipos.First(item=> item.Id == Id); //Devuelve el primer elemento que encuentre con ese ID

            return Equipo;
        }


        public bool ActualizarEquipo(int Id, equipo Equipo)
        {
            
            var equipoExistente = Equipos.First(item => item.Id == Id); 
            if (equipoExistente == null)
            {
                return false;
            } 

            equipoExistente.partidosJugados = Equipo.partidosJugados; //Estas lineas asignan a los datos del equipo actual el nuevo valor ingresados 
            equipoExistente.partidosGanados = Equipo.partidosGanados;
            equipoExistente.partidosEmpatados = Equipo.partidosEmpatados;
            equipoExistente.partidosPerdidos = Equipo.partidosPerdidos;

            GuardarEnJson();

            return true;
            
        }

        //Para las funcionalidades con el archivo Json me ayude de GPT
        private void CargarDesdeJson()
        {
            if (File.Exists("equipos.json"))
            {
                string json = File.ReadAllText("equipos.json");
                var equiposDesdeArchivo = JsonSerializer.Deserialize<List<equipo>>(json); //Convierte el texto Json leido en una lista de objetos de tipo equipo
                if (equiposDesdeArchivo != null)
                    Equipos = equiposDesdeArchivo;
            }
        }

        private void GuardarEnJson()
        {
            string json = JsonSerializer.Serialize(Equipos, new JsonSerializerOptions { WriteIndented = true }); //Hace que el Json se convierta a un formato legible
            File.WriteAllText("equipos.json", json); //El WriteAllText escribe el contenido en el archivo 
        }

    }
}
