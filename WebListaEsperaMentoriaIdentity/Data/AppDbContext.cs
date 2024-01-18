using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebListaEsperaMentoriaIdentity.Models;

namespace WebListaEsperaMentoriaIdentity.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options){}

        public DbSet<PacienteModel> PACIENTE { get; set; }
        public DbSet<ProfissionalModel> PROFISSIONAL { get; set; }
        public DbSet<EspecialidadeModel> ESPECIALIDADE { get; set;}


       
    }

    
    
}
