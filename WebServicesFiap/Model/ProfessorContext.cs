using Microsoft.EntityFrameworkCore;

namespace WebServicesFiap.Model
{
    public class ProfessorContext : DbContext
    {
        public ProfessorContext(DbContextOptions<ProfessorContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Professor> Professores { get; set; }
    }
}
