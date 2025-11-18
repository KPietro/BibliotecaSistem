using BibliotecaSistem.Models;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaSistem.Data
{
    public class BibliotecaContext : DbContext
    {
        public BibliotecaContext() { }
        public BibliotecaContext(DbContextOptions<BibliotecaContext> options) : base(options) { }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Emprestimo> Emprestimos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = "server=localhost;database=BibliotecaDB;user=root;password=";

                optionsBuilder.UseMySql(connectionString,
                    new MySqlServerVersion(new Version(8, 0, 21)));
            }
        }
    }
}