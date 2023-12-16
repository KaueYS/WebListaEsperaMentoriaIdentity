using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace WebListaEsperaMentoriaIdentity.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public UsuarioController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var users = _userManager.Users.ToList();
            return View(users);
        }
    }
}
