using Andrade_LigaPro.Models;
using Andrade_LigaPro.Repositorios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Andrade_LigaPro.Controllers
{
    public class EquipoController : Controller
    {
        public EquipoRepository _repository ;

        public EquipoController()
        {
            _repository = new EquipoRepository();
        }
        public ActionResult View()
        {
            return View();
        }
        public ActionResult List()
        {
          
            var equipos = _repository.DevuelveListadoEquipo();

            equipos = equipos.OrderByDescending(item => item.Puntos);
         


            return View(equipos);
        }
        [HttpPost]
        public ActionResult Edit(int Id, equipo Equipo)
        {
            
            try
            {
                //Proceso de Guardado

                _repository.ActualizarEquipo(Id, Equipo);
                return RedirectToAction(nameof(List));
            }
            catch
            {
                return View();
            }

        }




    }
}
