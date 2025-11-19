using BibliotecaCLI.Data;
using BibliotecaCLI.Models;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore; 

namespace BibliotecaCLI.Services
{
    public class EmprestimoService
    {
        private readonly BibliotecaContext _context = new BibliotecaContext();

        public void EmprestarLivro(Usuario usuarioLogado)
        {
            Console.WriteLine("--- Realizar Empréstimo ---");
            Console.Write("Digite o ID do Livro que deseja emprestar: ");

            if (!int.TryParse(Console.ReadLine(), out int livroId))
            {
                Console.WriteLine("ID inválido.");
                return;
            }

            var livro = _context.Livros.FirstOrDefault(l => l.Id == livroId);

            if (livro == null)
            {
                Console.WriteLine("Livro não encontrado.");
                return;
            }

            if (!livro.Disponivel)
            {
                Console.WriteLine("Este livro já está emprestado.");
                return;
            }


            livro.Disponivel = false;

            var novoEmprestimo = new Emprestimo
            {
                UsuarioId = usuarioLogado.Id,
                LivroId = livro.Id,
                DataEmprestimo = DateTime.Now,
                DataDevolucao = null 
            };

            _context.Emprestimos.Add(novoEmprestimo);
            _context.SaveChanges(); 

            Console.WriteLine($"Livro '{livro.Titulo}' emprestado com sucesso para {usuarioLogado.Nome}!");
        }

        // Dentro de EmprestimoService.cs

        public void DevolverLivro(Usuario usuarioLogado)
        {
            Console.WriteLine("--- Devolver Livro ---");
            Console.Write("Digite o ID do Livro que você vai devolver: ");

            if (!int.TryParse(Console.ReadLine(), out int livroId))
            {
                Console.WriteLine("ID inválido.");
                return;
            }

            var emprestimo = _context.Emprestimos
                .FirstOrDefault(e => e.LivroId == livroId &&
                                     e.UsuarioId == usuarioLogado.Id &&
                                     e.DataDevolucao == null);

            if (emprestimo == null)
            {
                Console.WriteLine("Empréstimo não encontrado. Você não pegou este livro ou ele já foi devolvido.");
                return;
            }
            emprestimo.DataDevolucao = DateTime.Now;
            var livro = _context.Livros.FirstOrDefault(l => l.Id == livroId);

            if (livro != null)
            {
                livro.Disponivel = true;
            }
            _context.SaveChanges();

            Console.WriteLine($"Livro '{livro?.Titulo ?? "ID: " + livroId}' devolvido com sucesso! Agora está disponível para empréstimo.");
        }

        public void ListarMeusEmprestimos(Usuario usuarioLogado)
        {
            Console.WriteLine($"--- Empréstimos Ativos de {usuarioLogado.Nome} ---");

            var emprestimos = _context.Emprestimos
                .Include(e => e.Livro) 
                .Where(e => e.UsuarioId == usuarioLogado.Id && e.DataDevolucao == null)
                .ToList();

            if (emprestimos.Count == 0)
            {
                Console.WriteLine("Você não possui nenhum empréstimo ativo.");
                return;
            }

            foreach (var emp in emprestimos)
            {
                Console.WriteLine($"ID Livro: {emp.LivroId} | Título: {emp.Livro.Titulo} | Data Empréstimo: {emp.DataEmprestimo.ToShortDateString()}");
            }
        }
    }
}