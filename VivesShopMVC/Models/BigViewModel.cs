using VivesShopMVC.Controllers;
using VivesShopMVC.Data;

namespace VivesShopMVC.Models
{
    public class BigViewModel
    {
        public ShopItemsDb ItemsDataBase { get; set; }
        public Cart Cart { get; set; }
    }
}
