using VivesShopMVC.Models;

namespace VivesShopMVC.Controllers
{
    public class Cart
    {
        public IList<Product> products { get; set; }

        public void initialize()
        {
            products = new List<Product> { };
        }

        public double TotalUnit()
        {
            double som = 0.0;
            foreach (Product p in products)
            {
                som += p.Prijs;
            }
            return som;
        }
    }
}
