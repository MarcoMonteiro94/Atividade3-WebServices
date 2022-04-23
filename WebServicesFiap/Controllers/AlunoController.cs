using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebServicesFiap.Model;
using WebServicesFiap.Repositories;

namespace WebServicesFiap.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoRepository _alunoRepository;
        public AlunoController(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Aluno>> GetAlunos()
        {
            return await _alunoRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Aluno>> GetAlunos(int id)
        {
            return await _alunoRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Aluno>> PostAlunos([FromBody] Aluno aluno)
        {
            var newAluno = await _alunoRepository.Create(aluno);
            return CreatedAtAction(nameof(GetAlunos), new { id = newAluno.Id }, newAluno);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAluno(int id)
        {
            var alunoToDelete = await _alunoRepository.Get(id);

            if (alunoToDelete == null)
                return NotFound();

            await _alunoRepository.Delete(alunoToDelete.Id);
            return NoContent();

        }

        [HttpPut]
        public async Task<ActionResult> PutAlunos(int id, [FromBody] Aluno aluno)
        {
            if (id != aluno.Id)
                return BadRequest();

            await _alunoRepository.Update(aluno);
            return NoContent();
        }
    }
}
