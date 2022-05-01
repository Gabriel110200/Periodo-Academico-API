using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; 

namespace WebApplication3.Models
{
    public class Turma
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string nome { get; set; }







    }
}
