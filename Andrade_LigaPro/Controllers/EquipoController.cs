using Andrade_LigaPro.Models;
using Andrade_LigaPro.Repositorios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Andrade_LigaPro.Controllers
{
    public class EquipoController : Controller
    {
    
        public ActionResult View()
        {
            return View();
        }
        public ActionResult List()
        {
            EquipoRepository equipoRepository = new EquipoRepository();
            var equipos = equipoRepository.DevuelveListadoEquipo();

            equipos = equipos.OrderByDescending(item => item.Puntos);
            // equipos = equipos.Where(item => item.Nombre == "Liga de Quito");


            return View(equipos);
        }


    }
}
