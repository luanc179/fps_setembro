using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AtletaApi.Models
{
    public class ModelContext : DbContext
    {
        public DbSet<Atleta> Atletas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connString = "server=localhost; database=Atletas; user=aluno; password=aluno";

           optionsBuilder.UseMySql(connString, ServerVersion.AutoDetect(connString));
        }
    }
}