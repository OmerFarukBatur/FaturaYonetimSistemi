using Microsoft.AspNetCore.Mvc;

namespace FaturaYonetimSistemiUI.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }       
        public IActionResult Contact()
        {
            return View();
        }
        
    }
}
