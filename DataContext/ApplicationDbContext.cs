using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebApi.Models;

namespace WebApi.DataContext
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }


        public DbSet<PacienteModel> Paciente {  get; set; }
        public DbSet<ModeloExameModel> ModeloExame { get; set; }
    }


        
}
