using Microsoft.AspNetCore.Mvc;

namespace FaturaYonetimSistemiUI.Controllers
{
    public class UserAdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult NewUser()
        {
            return View();
        }

        public IActionResult UpdateUser()
        {
            return View();
        }

        public IActionResult DeleteUser()
        {
            return View();
        }
    }
}
