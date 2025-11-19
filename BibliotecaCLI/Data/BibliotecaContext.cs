using BibliotecaCLI.Models;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaCLI.Data
{
    public class BibliotecaContext : DbContext
    {
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Emprestimo> Emprestimos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=localhost;Database=biblioteca_db;Uid=root;Pwd= ;";

            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Livro>().ToTable("Livros");
            modelBuilder.Entity<Usuario>().ToTable("Usuarios");
            modelBuilder.Entity<Emprestimo>().ToTable("Emprestimos");
        }
    }
}