using Microsoft.EntityFrameworkCore;

namespace WebServicesFiap.Model
{
    public class AlunoContext : DbContext
    {
        public AlunoContext(DbContextOptions<AlunoContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Aluno> Alunos { get; set; }
    }
}
