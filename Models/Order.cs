using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Carnival.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0.")]
        public int Quantity { get; set; }

        public virtual Customer Customer { get; set; }
        [Required]
        public int CustomerID { get; set; }

        public virtual Food_Product Food_Product { get; set; }
        [Required]
        public int FoodID { get; set; }

        public virtual Stall Stall { get; set; }
        [Required]
        public int StallID { get; set; }
    }
}