using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace AtletaApi.Models
{
    public class ModelContext : IdentityDbContext
    {
        public DbSet<Atleta> Atletas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connString = "server=localhost; database=Atletas; user=aluno; password=aluno";

           optionsBuilder.UseMySql(connString, ServerVersion.AutoDetect(connString));
        }
    }
}