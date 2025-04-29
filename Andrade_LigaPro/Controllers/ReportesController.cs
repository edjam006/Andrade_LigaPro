using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Andrade_LigaPro.Data;
using System.Linq;

namespace Andrade_LigaPro.Controllers
{
    public class ReportesController : Controller
    {
        private readonly Andrade_LigaProContext _context;

        public ReportesController(Andrade_LigaProContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            // Aqui en estas se define los controladores para obtener las tablas de reportes
            // el include lo que hace es la relación con la tabla Equipo
            //el OrderByDescending como se hizo en la clase se ordena de mayor a menor en este primer caso por goles despues por asistencia y en la otra por puntos
            var topGoleadores = _context.Jugador
                .Include(j => j.Equipo)
                .OrderByDescending(j => j.Goles)
                .Take(5)//toma los 5 primeros elementos y despues se hacen lista
                .ToList();

            var topAsistencias = _context.Jugador
                .Include(j => j.Equipo)
                .OrderByDescending(j => j.Asistencias)
                .Take(5)
                .ToList();

            //Aqui se hace casi lo mismo que en las otras dos funciones pero para sacar el presupuesto se hizo una suma de los sueldos de cada equipo 
            var equiposTopPresupuesto = _context.equipo
                .Select(e => new
                {
                    Nombre = e.Nombre,
                    Puntos = _context.Jugador
                        .Where(j => j.EquipoId == e.Id) //aqui se obtiene los jugadores por el id del equipo 
                        .Sum(j => (decimal?)j.Sueldo) ?? 0 //y aqui sumamos todos los sueldos de los jugadores de ese equipo, y el equipo que sume mas valor respecto a los sueldos es el que se enviara como con mayor presupuesto
                })
                .OrderByDescending(e => e.Puntos)
                .Take(5)
                .ToList();

            






            ViewBag.TopGoleadores = topGoleadores;
            ViewBag.TopAsistencias = topAsistencias;
            ViewBag.TopPresupuesto = equiposTopPresupuesto;

            return View();
        }
    }
}
