using System.ComponentModel.DataAnnotations;

namespace Carnival.Models
{
    public class Login
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}