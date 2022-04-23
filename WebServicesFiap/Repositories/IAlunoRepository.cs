using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServicesFiap.Model;

namespace WebServicesFiap.Repositories
{
    public interface IAlunoRepository
    {
        Task<IEnumerable<Aluno>> Get();

        Task<Aluno> Get(int Id);

        Task<Aluno> Create(Aluno aluno);

        Task Update(Aluno aluno);

        Task Delete(int Id);
    }
}
