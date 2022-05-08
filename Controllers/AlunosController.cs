using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
 
    [ApiController]
    public class AlunosController : ControllerBase
    {
        private readonly DataContext _context;

        public AlunosController(DataContext context)
        {
            _context = context;
        }


        [HttpGet]
        [Route("")]
   
        //retorna uma lista de alunos
        public async Task<ActionResult<List<Aluno>>> Get([FromServices] DataContext _db, [FromQuery] int skip = 0, [FromQuery] int take = 25)
        {
            var total = await _db.Alunos.CountAsync();

            int pages = total / take;
            

            var alunos = await _db.Alunos.AsNoTracking().Skip(skip).Take(take).ToListAsync();
            var turmas = await _db.Turmas.AsNoTracking().ToListAsync();

            


            if (alunos.Count == 0)
            {
                return NotFound();
            }

         

            return Ok(new { 
                total, 
                pages,
                data = alunos
            });
        }


        // Retorna alunos que estão registrados na turma pelo nome da turma
        [HttpGet("turma/{nomeTurma}")]
        public async Task<ActionResult<IEnumerable<Aluno>>> GetAlunos(string nomeTurma)
        {

            var alunos  = await _context.Alunos.ToArrayAsync();
            var turma = await _context.Turmas.ToArrayAsync();

            var teste = alunos.Where(x => x.Turma.nome.Equals(nomeTurma)).ToList();

            return Ok(teste);
          
        }

       

        //  retorna aquele aluno em especifico
        [HttpGet("{id}")]
        public async Task<ActionResult<Aluno>> GetAluno(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);

            if (aluno == null)
            {
                return NotFound();
            }

            return Ok(aluno);
        }

        // Atualiza as informações do aluno, fazendo o calcula da media

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAluno(int id, Aluno aluno)
        {
            if (id==0 || id==null)
            {
                return BadRequest();
            }

            decimal nota1 = aluno.Nota1.Equals(null) ? 0 : aluno.Nota1;
            decimal nota2 = aluno.Nota2.Equals(null) ? 0 : aluno.Nota2;
            decimal nota3 = aluno.Nota3.Equals(null) ? 0 : aluno.Nota3;

            decimal media = calcularMedia(nota1, nota2, nota3);

            aluno.MediaFinal = media;

                

            try
            {
                _context.Alunos.Update(aluno);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlunoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Alunos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Aluno>> PostAluno(Aluno aluno)
        {

            decimal nota1 = aluno.Nota1.Equals(null) ? 0 : aluno.Nota1; 
            decimal nota2 = aluno.Nota2.Equals(null) ? 0 : aluno.Nota2;
            decimal nota3 = aluno.Nota3.Equals(null) ? 0 : aluno.Nota3;

            decimal media = calcularMedia(nota1, nota2, nota3);

            aluno.MediaFinal = media;


            _context.Alunos.Add(aluno);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAluno", new { id = aluno.Id }, aluno);
        }

        //Calcula a media Ponderada do aluno de acordo com as provas

        public decimal calcularMedia(decimal p1, decimal p2, decimal p3)
        {
            decimal peso1 = 1;
            decimal peso2 = peso1 * (decimal)1.2;
            decimal peso3 = peso1 * (decimal)1.4;

            decimal denominador = peso1 + peso2 + peso3;

            if(denominador==0)
            {
                return 0;
            }

            decimal media = (p1 * peso1 + p2 * peso2 + peso3 * p3) / denominador;

            return media;
        }



        // Remove aluno
        [HttpDelete("{id}")]
        public async Task<ActionResult<Aluno>> DeleteAluno(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno == null)
            {
                return NotFound();
            }

            _context.Alunos.Remove(aluno);
            await _context.SaveChangesAsync();

            return Ok(aluno);
        }

        private bool AlunoExists(int id)
        {
            return _context.Alunos.Any(e => e.Id == id);
        }
    }
}
