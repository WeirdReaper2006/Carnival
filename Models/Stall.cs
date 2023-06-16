using System.ComponentModel.DataAnnotations;

namespace Carnival.Models
{
    public class Stall
    {
        [Key]
        public int StallID { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Specialty { get; set; }
    }
}