using System.ComponentModel.DataAnnotations;

namespace VivesShopMVC.Models
{
    public class Product
    {
        [Required]
        public int Id { get; set; }
      
        public string Name { get; set; }
        [Required]
        public double Prijs { get; set; }
    }
}
