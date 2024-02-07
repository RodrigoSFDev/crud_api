using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiFuncionario.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiFuncionario
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        public DbSet<FuncionarioModel> Funcionarios { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured) return;
            var connectionString = "Server=localhost;Database=Funcionario;User=SA;Password=FuncionariosHotel12!;TrustServerCertificate=True";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}