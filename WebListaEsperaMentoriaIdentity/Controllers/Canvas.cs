using Microsoft.AspNetCore.Mvc;

namespace WebListaEsperaMentoriaIdentity.Controllers
{
    public class Canvas : Controller
    {
        public IActionResult CanvasView()
        {
            return View();
        }
    }
}
