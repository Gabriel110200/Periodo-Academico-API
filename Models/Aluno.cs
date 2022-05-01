using Castle.MicroKernel.SubSystems.Conversion;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
    public class Aluno
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }


        [Column(TypeName = "decimal(18,4)")]
        [Range(0, 10, ErrorMessage = "Notas deverão ser entre 0 e 10 apenas")]

        public decimal Nota1 { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        [Range(0, 10, ErrorMessage = "Notas deverão ser entre 0 e 10 apenas")]

        public decimal Nota2 { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        [Range(0, 10, ErrorMessage = "Notas deverão ser entre 0 e 10 apenas")]

        public decimal Nota3 { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        [Range(0, 10, ErrorMessage = "Media final deverá ser entre 0 e 10")]

        public decimal MediaFinal { get; set; }

        public Turma Turma { get; set; }

        public int  TurmaId { get; set; }   






    }
}
