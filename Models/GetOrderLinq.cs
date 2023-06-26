using System.ComponentModel.DataAnnotations;

namespace Carnival.Models
{
    public class GetOrderLinq
    {
        [Key]
        public int OrderID { get; set; }
        public string Customer_Name { get; set; }
        public string ContactNo { get; set; }
        public string Food { get; set; }
        public string Stall_Name { get; set; }
        public int Quantity { get; set; }
    }
}