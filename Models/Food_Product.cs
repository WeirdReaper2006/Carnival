using System.ComponentModel.DataAnnotations;

namespace Carnival.Models
{
    public class Food_Product
    {
        [Key]
        public int FoodID { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }
    }
}