namespace VivesShopMVC.Models
{
    
    public class CartModel
    {
        public IList<Product> cart { get; set; }
        
        public void initialize()
        {
            cart = new List<Product>();

        }

        public Product getProduct(int id)
        {
            return cart[id];
        }
}
   
}
