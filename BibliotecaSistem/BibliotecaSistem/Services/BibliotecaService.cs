using BibliotecaSistem.Data;
using BibliotecaSistem.Models;
using System;
using System.Linq;

namespace BibliotecaSistem.Services
{
    public class BibliotecaService
    {
        // Método para adicionar um livro no banco
        public void CadastrarLivro(string titulo, string autor, int paginas, string serial)
        {
            // 1. Abrimos a conexão com o banco
            using (var context = new BibliotecaContext())
            {
                // 2. Criamos o objeto Livro (na memória do C#)
                var novoLivro = new Livro
                {
                    Titulo = titulo,
                    Autor = autor,
                    Paginas = paginas,
                    NumeroSerial = serial,
                    Disponivel = true // Por padrão, livro novo está livre
                };

                // 3. Avisamos o Contexto: "Olha, tem esse livro novo aqui"
                context.Livros.Add(novoLivro);

                // 4. O Grande Momento: Salva tudo no MySQL de verdade
                context.SaveChanges();

                Console.WriteLine("📚 Livro salvo com sucesso no banco!");
            }
        }

        // Método para listar todos os livros (só para a gente testar depois)
        public void ListarLivros()
        {
            using (var context = new BibliotecaContext())
            {
                // O .ToList() vai no banco, pega tudo e traz para o C#
                var livros = context.Livros.ToList();

                Console.WriteLine("\n--- Lista de Livros ---");
                foreach (var livro in livros)
                {
                    Console.WriteLine($"ID: {livro.Id} | Título: {livro.Titulo} | Autor: {livro.Autor}");
                }
            }
        }
    }
}