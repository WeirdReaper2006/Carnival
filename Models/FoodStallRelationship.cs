using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Carnival.Models
{
    public class FoodStallRelationship
    {
        //[Key]
        //public int RefID { get; set; }

        //[Required]
        //public virtual Food_Product Food_Product { get; set; }
        //public int FoodID { get; set; }

        //[Required]
        //public virtual Stall Stall { get; set; }
        //public int StallID { get; set; }

        public virtual Food_Product Food_Product { get; set; }
        [Key]
        [Column(Order = 1)]
        public int FoodID { get; set; }

        public virtual Stall Stall { get; set; }
        [Key]
        [Column(Order = 2)]
        public int StallID { get; set; }
    }
}