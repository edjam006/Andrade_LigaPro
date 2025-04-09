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
          
            var equipos = _repository.DevuelveListadoEquipos();

            equipos = equipos.OrderByDescending(item => item.Puntos);
         


            return View(equipos);
        }
        [HttpPost]
        public ActionResult Edit(int Id, equipo Equipo)
        {
            
            try
            {
                //Proceso de Guardado
                bool actualizado = _repository.ActualizarEquipo(Id, Equipo); //Equipo es el objeto nuevo actualizado como se designo en el repositorio y se indica el id  
                
                
                if(actualizado){
                    return RedirectToAction(nameof(List)); //Si  el metodo da true significa que se actualizo correctamente y se redirige a la vista normal
                }
                else {
                    return NotFound(); //Si no encuentra el ID retorna error 404
                }
            }
            catch
            {
                return View();
            }

        }




    }
}
