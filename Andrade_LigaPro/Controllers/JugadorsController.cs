using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Andrade_LigaPro.Data;
using Andrade_LigaPro.Models;

namespace Andrade_LigaPro.Controllers
{
    public class JugadorsController : Controller
    {
        private readonly Andrade_LigaProContext _context;

        public JugadorsController(Andrade_LigaProContext context)
        {
            _context = context;
        }

        // GET: Jugadors
        public IActionResult Index(int? equipoId)
        {
            var jugadores = _context.Jugador.Include(j => j.Equipo).AsQueryable();

            if (equipoId.HasValue)
            {
                jugadores = jugadores.Where(j => j.EquipoId == equipoId.Value);
            }

            ViewBag.Equipos = new SelectList(_context.equipo.OrderBy(e => e.Nombre), "Id", "Nombre", equipoId);

           


            return View(jugadores.ToList());
        }

        // GET: Jugadors/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null) return NotFound();

            var jugador = _context.Jugador
                .Include(j => j.Equipo)
                .FirstOrDefault(m => m.Id == id);

            if (jugador == null) return NotFound();

            return View(jugador);
        }

        // GET: Jugadors/Create
        public IActionResult Create()
        {
            ViewBag.Equipos = new SelectList(_context.equipo, "Id", "Nombre");
            return View();
        }

        // POST: Jugadors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Jugador jugador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jugador);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Equipos = new SelectList(_context.equipo, "Id", "Nombre", jugador.EquipoId);
            return View(jugador);
        }

        // GET: Jugadors/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();

            var jugador = _context.Jugador.Find(id);
            if (jugador == null) return NotFound();

            ViewBag.Equipos = new SelectList(_context.equipo, "Id", "Nombre", jugador.EquipoId);
            return View(jugador);
        }

        // POST: Jugadors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Jugador jugador)
        {
            if (id != jugador.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jugador);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Jugador.Any(e => e.Id == jugador.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Equipos = new SelectList(_context.equipo, "Id", "Nombre", jugador.EquipoId);
            return View(jugador);
        }

        // GET: Jugadors/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();

            var jugador = _context.Jugador
                .Include(j => j.Equipo)
                .FirstOrDefault(m => m.Id == id);

            if (jugador == null) return NotFound();

            return View(jugador);
        }

        // POST: Jugadors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var jugador = _context.Jugador.Find(id);
            if (jugador != null)
            {
                _context.Jugador.Remove(jugador);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
