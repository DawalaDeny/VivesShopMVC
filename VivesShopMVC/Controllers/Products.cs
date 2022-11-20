using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;
using VivesShopMVC.Data;
using VivesShopMVC.Models;

namespace VivesShopMVC.Controllers
{
    public class Products : Controller
    {
        private readonly BigViewModel _database;

        public Products(BigViewModel database)
        {
            _database = database;
        }
        public IActionResult Index()
        {
            var products = _database.ItemsDataBase.Products;
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
            var maxId = _database.ItemsDataBase.Products.Max(x => x.Id);
            var id = maxId + 1;
            prod.Id = id;
            String naam = prod.Name;
            double prijs = prod.Prijs;
            if (!String.IsNullOrEmpty(naam) && prijs>0)
            {
                _database.ItemsDataBase.Products.Add(prod);
            }
            
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var prod= _database.ItemsDataBase.Products.SingleOrDefault(o => o.Id == id);
            
            if (prod is null)
            {
                return RedirectToAction("Index");
            }
            return View(prod);
        }

        [HttpPost] public IActionResult Edit(int id, Product p)
        {
            if (!ModelState.IsValid)
            {
                return View(p);
            }

            var prod = _database.ItemsDataBase.Products
                .SingleOrDefault(o => o.Id == id);
            
            if (prod is null)
            {
                return RedirectToAction("Index");
            }

            prod.Name = p.Name;
            prod.Prijs = p.Prijs;

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var prod = _database.ItemsDataBase.Products.SingleOrDefault(o => o.Id == id);

            if (prod is null)
            {
                return RedirectToAction("Index");
            }

            return View(prod);
        }
        [HttpPost("[controller]/Delete/{id:int?}")]
        public IActionResult DeleteConfirmed(int id)
        {
            var prod = _database.ItemsDataBase.Products.SingleOrDefault(o => o.Id == id);
            
            if (prod is null)
            {
                return RedirectToAction("Index");
            }
            _database.ItemsDataBase.Products.Remove(prod);
            return RedirectToAction("Index");
        }
    }
}

