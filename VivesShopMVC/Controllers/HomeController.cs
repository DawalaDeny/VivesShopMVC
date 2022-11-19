using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VivesShopMVC.Data;
using VivesShopMVC.Models;

namespace VivesShopMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ShopItemsDb _database;

        public HomeController(ShopItemsDb database)
        {
            _database = database;
        }

        public IActionResult Index()
        {
            return View(_database);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}