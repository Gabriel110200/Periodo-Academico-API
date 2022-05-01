using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class Professor
    {
        [Key]
        public int Id { get; set; } 

        [Required]
        public string Name { get; set; }

        public string Email { get; set; }

        
    }
}
