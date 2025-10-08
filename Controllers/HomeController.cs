using Microsoft.AspNetCore.Mvc;

namespace CrudApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Clientes()
        {
            return View();
        }

        public IActionResult Produtos()
        {
            return View();
        }
    }
}
