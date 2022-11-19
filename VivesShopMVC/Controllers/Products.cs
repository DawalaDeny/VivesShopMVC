using Microsoft.AspNetCore.Mvc;

namespace VivesShopMVC.Controllers
{
    public class Products : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
