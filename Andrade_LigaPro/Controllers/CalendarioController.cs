using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Andrade_LigaPro.Controllers
{
    public class CalendarioController : Controller
    {
        // GET: CalendarioController
        public ActionResult calendarioPartidos()
        {
            return View();
        }

       
        
    }
}
