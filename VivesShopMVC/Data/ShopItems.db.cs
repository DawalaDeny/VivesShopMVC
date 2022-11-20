using VivesShopMVC.Controllers;
using VivesShopMVC.Models;

namespace VivesShopMVC.Data
{

    public class ShopItemsDb
    {
        public IList<Product> Products { get; set; } = new List<Product>();
        public void Seed()
        {
            Products = new List<Product>
            {
                new()
                {
                    Id = 1,
                    Name = "Medium friet",
                    Prijs = 3

                },
                new()
                {
                    Id = 2,
                    Name = "Frikandel",
                    Prijs = 2
                   
                },
                new()
                {
                    Id = 3,
                    Name = "Cola Zero",
                    Prijs = 2
                   
                },
                new()
                {
                    Id = 4,
                    Name = "Water",
                    Prijs = 1.5
                    
                },
                new()
                {
                Id = 5,
                Name = "Mayo",
                Prijs = 0.5

            }
            };
        }
    }

}
