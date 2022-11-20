using Microsoft.AspNetCore.Mvc;
using VivesShopMVC.Data;
using VivesShopMVC.Models;

namespace VivesShopMVC.Controllers
{
    public class Products : Controller
    {
        private readonly ShopItemsDb _database;

        public Products(ShopItemsDb database)
        {
            _database = database;
        }
        public IActionResult Index()
        {
            var products = _database.Products;
            return View(products);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View("Form");
        }

        [HttpPost]
        public IActionResult Create(Product prod)
        {
            var maxId = _database.Products.Max(x => x.Id);
            var id = maxId + 1;
            prod.Id = id;
            String naam = prod.Name;
            double prijs = prod.Prijs;
            if (!String.IsNullOrEmpty(naam) && prijs>0)
            {
                _database.Products.Add(prod);
            }
            
            return RedirectToAction("Index");
        }
    }
}
