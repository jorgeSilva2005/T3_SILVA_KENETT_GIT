using Microsoft.AspNetCore.Mvc;

namespace T3_SILVA_KENETT.Controllers
{
    public class InformacionController : Controller
    {
        public IActionResult Arquitectura()
        {
            return View();
        }

        public IActionResult Diseno()
        {
            return View();
        }
    }
}