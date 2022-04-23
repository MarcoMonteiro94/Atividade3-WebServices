using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebServicesFiap.Model;
using WebServicesFiap.Repositories;

namespace WebServicesFiap.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly IProfessorRepository _professorRepository;
        public ProfessorController(IProfessorRepository professorRepository)
        {
            _professorRepository = professorRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Professor>> GetProfessores()
        {
            return await _professorRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Professor>> GetProfessores(int id)
        {
            return await _professorRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Professor>> PostProfessores([FromBody] Professor professor)
        {
            var newProfessor = await _professorRepository.Create(professor);
            return CreatedAtAction(nameof(GetProfessores), new { id = newProfessor.Id }, newProfessor);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProfessor(int id)
        {
            var professorToDelete = await _professorRepository.Get(id);

            if (professorToDelete == null)
                return NotFound();

            await _professorRepository.Delete(professorToDelete.Id);
            return NoContent();

        }

        [HttpPut]
        public async Task<ActionResult> PutProfessor(int id, [FromBody] Professor professor)
        {
            if (id != professor.Id)
                return BadRequest();

            await _professorRepository.Update(professor);
            return NoContent();
        }
    }
}
