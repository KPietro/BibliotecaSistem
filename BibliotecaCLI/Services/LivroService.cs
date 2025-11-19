using BibliotecaCLI.Data;
using BibliotecaCLI.Models;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore; 

namespace BibliotecaCLI.Services
{
    public class LivroService
    {
        private readonly BibliotecaContext _context = new BibliotecaContext();

        public void CadastrarLivro()
        {
            Console.WriteLine("--- Cadastro de Novo Livro ---");
            Console.Write("Título: ");
            string titulo = Console.ReadLine()!;

            Console.Write("Autor: ");
            string autor = Console.ReadLine()!;

            if (string.IsNullOrEmpty(titulo) || string.IsNullOrEmpty(autor))
            {
                Console.WriteLine("Título e Autor não podem ser vazios.");
                return;
            }

            var novoLivro = new Livro
            {
                Titulo = titulo,
                Autor = autor,
                Disponivel = true
            };

            _context.Livros.Add(novoLivro);
            _context.SaveChanges();

            Console.WriteLine("Livro cadastrado com sucesso!");
        }

        public void ListarTodosLivros()
        {
            Console.WriteLine("--- Lista de Todos os Livros ---");

            var livros = _context.Livros.AsNoTracking().ToList();

            if (livros.Count == 0)
            {
                Console.WriteLine("Nenhum livro cadastrado.");
                return;
            }

            foreach (var livro in livros)
            {
                string status = livro.Disponivel ? "Disponível" : "Emprestado";
                Console.WriteLine($"ID: {livro.Id} | Título: {livro.Titulo} | Autor: {livro.Autor} | Status: {status}");
            }
        }

        public void ListarLivrosDisponiveis()
        {
            Console.WriteLine("--- Lista de Livros Disponíveis ---");

            var livros = _context.Livros.Where(l => l.Disponivel == true).AsNoTracking().ToList();

            if (livros.Count == 0)
            {
                Console.WriteLine("Nenhum livro disponível no momento.");
                return;
            }

            foreach (var livro in livros)
            {
                Console.WriteLine($"ID: {livro.Id} | Título: {livro.Titulo} | Autor: {livro.Autor}");
            }
        }
    }
}