using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    [ApiController]
    [Route("api/turma")]

    public class TurmaController : ControllerBase
    {
        private  DataContext _db;

        public TurmaController(DataContext db)
        {
            _db = db;
        }

        [HttpGet]
        [Route("")]


        public async Task<ActionResult<List<Turma>>> Get([FromServices] DataContext _db)
        {
            var turmas = await _db.Turmas.ToListAsync();

           if(turmas.Count ==0 )
            {
                return NotFound();
            }

            return turmas;
        }



        [HttpPost]
        [Route("")]
       // [ValidateAntiForgeryToken]

        public async Task<ActionResult<Turma>> Create([FromBody] Turma turma)
        {

            var turmas = await _db.Turmas.ToListAsync();

            if(turmas.Count >=3)
            {
                return BadRequest("Não é possível criar mais do que 3 Turmas");
            }
            

            if(ModelState.IsValid)
            {
                _db.Turmas.Add(turma);
                await _db.SaveChangesAsync();
                return turma;

            }
            else
            {
                return BadRequest(ModelState);
            }
        }


       




    }
}
