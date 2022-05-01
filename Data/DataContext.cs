using Microsoft.EntityFrameworkCore;
using WebApplication3.Models; 

namespace WebApplication3.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

       

        public  DbSet<Turma> Turmas { get; set; }
        public DbSet<Aluno> Alunos { get; set; }

    }
}
