using Andrade_LigaPro.Data;
using Andrade_LigaPro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.IO;
using System.Text.Json;



namespace Andrade_LigaPro.Controllers
{
    public class EquipoController : Controller
    {
        private readonly Andrade_LigaProContext _context;


        public EquipoController(Andrade_LigaProContext context)
        {
            _context = context;
            CargarEquiposDesdeJson();
        }

        public IActionResult View()
        {
            return View();
        }

        public IActionResult List()
        {
            var equipos = _context.Set<equipo>().ToList();
            equipos = equipos.OrderByDescending(e => e.Puntos).ToList();
            return View(equipos);
        }

        [HttpPost]
        public IActionResult Edit(int Id, equipo Equipo)
        {
            try
            {
                var equipoExistente = _context.Set<equipo>().FirstOrDefault(e => e.Id == Id);
                if (equipoExistente == null)
                    return NotFound();

                equipoExistente.partidosJugados = Equipo.partidosJugados;
                equipoExistente.partidosGanados = Equipo.partidosGanados;
                equipoExistente.partidosEmpatados = Equipo.partidosEmpatados;
                equipoExistente.partidosPerdidos = Equipo.partidosPerdidos;

                _context.SaveChanges();
                return RedirectToAction(nameof(List));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Descripcion(int id)
        {
            var equipo = _context.Set<equipo>().FirstOrDefault(e => e.Id == id);
            if (equipo == null)
            {
                return NotFound();
            }
            return View(equipo);
        }
        // Función recomendada por IA para que se carguen en la base de datos los equipos que ya tenías en el JSON
        private void CargarEquiposDesdeJson()
        {
            if (!_context.equipo.Any())
            {
                string ruta = Path.Combine(Directory.GetCurrentDirectory(), "equipos.json");
                if (System.IO.File.Exists(ruta))
                {
                    var json = System.IO.File.ReadAllText(ruta);
                    var equipos = JsonSerializer.Deserialize<List<equipo>>(json);

                    if (equipos != null)
                    {
                        foreach (var eq in equipos)
                        {
                            eq.Id = 0; // fuerza a SQL Server a autogenerar el Id
                        }

                        _context.equipo.AddRange(equipos);
                        _context.SaveChanges();
                    }

                }
            }
        }


    }
}
