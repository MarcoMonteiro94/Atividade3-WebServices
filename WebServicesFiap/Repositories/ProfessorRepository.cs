using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServicesFiap.Model;

namespace WebServicesFiap.Repositories
{
    public class ProfessorRepository : IProfessorRepository
    {
        public readonly ProfessorContext _context;
        public ProfessorRepository(ProfessorContext context)
        {
            _context = context;
        }

        public async Task<Professor> Create(Professor professor)
        {
            _context.Professores.Add(professor);
            await _context.SaveChangesAsync();

            return professor;
        }

        public async Task Delete(int id)
        {
            var professorToDelete = await _context.Professores.FindAsync(id);
            _context.Professores.Remove(professorToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Professor>> Get()
        {
            return await _context.Professores.ToListAsync();
        }

        public async Task<Professor> Get(int id)
        {
            return await _context.Professores.FindAsync(id);
        }

        public async Task Update(Professor professor)
        {
            _context.Entry(professor).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
