using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VivesShopMVC.Data;
using VivesShopMVC.Models;

namespace VivesShopMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly BigViewModel _database;

        public HomeController(BigViewModel database)
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
        public IActionResult ToevoegenCart(int id)
        {
            var p = _database.ItemsDataBase.Products.SingleOrDefault(pr => pr.Id == id);

            if (p is null)
            {
                return RedirectToAction("Index");
            }
            _database.Cart.products.Add(p);
            return RedirectToAction("Index");
            
        }

        public IActionResult VerwijderenCart(int id)
        {
            Product p = _database.ItemsDataBase.Products.SingleOrDefault(pr => pr.Id == id);
            _database.Cart.products.Remove(p);
            return RedirectToAction("index");
        }



        public IActionResult Checkout()

        {
            
            return View("BetaalScherm", _database.Cart.products);
        }

        public IActionResult Betaald()
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