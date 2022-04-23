using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServicesFiap.Model;

namespace WebServicesFiap.Repositories
{
    public interface IProfessorRepository
    {
        Task<IEnumerable<Professor>> Get();

        Task<Professor> Get(int Id);

        Task<Professor> Create(Professor professor);

        Task Update(Professor professor);

        Task Delete(int Id);
    }
}
