using BibliotecaCLI.Data;
using BibliotecaCLI.Models;
using System;
using System.Linq;

namespace BibliotecaCLI.Services
{
    public class UsuarioService
    {
        private readonly BibliotecaContext _context = new BibliotecaContext();

        public void CadastrarUsuario()
        {
            Console.WriteLine("--- Cadastro de Novo Usuário ---");
            Console.Write("Nome: ");
            string nome = Console.ReadLine()!;

            Console.Write("Email: ");
            string email = Console.ReadLine()!;

            // ADICIONE A SOLICITAÇÃO DA SENHA:
            Console.Write("Senha: ");
            string senha = Console.ReadLine()!;

            if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha))
            {
                Console.WriteLine("Nome, Email e Senha não podem ser vazios.");
                return;
            }

            var novoUsuario = new Usuario
            {
                Nome = nome,
                Email = email,
                Senha = senha
            };

            _context.Usuarios.Add(novoUsuario);
            _context.SaveChanges();

            Console.WriteLine($"Usuário cadastrado com sucesso! (ID: {novoUsuario.Id})");
        }

        public void ListarUsuarios()
        {
            Console.WriteLine("--- Lista de Todos os Usuários ---");
            var usuarios = _context.Usuarios.ToList();

            if (usuarios.Count == 0)
            {
                Console.WriteLine("Nenhum usuário cadastrado.");
                return;
            }

            foreach (var usuario in usuarios)
            {
                Console.WriteLine($"ID: {usuario.Id} | Nome: {usuario.Nome} | Email: {usuario.Email}");
            }
        }
        public Usuario? Login()
        {
            Console.WriteLine("--- Login de Usuário ---");
            Console.Write("Email: ");
            string email = Console.ReadLine()!;

            Console.Write("Senha: ");
            string senha = Console.ReadLine()!;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha))
            {
                Console.WriteLine("Email e Senha são obrigatórios.");
                return null;
            }
            var usuario = _context.Usuarios
                .FirstOrDefault(u => u.Email == email && u.Senha == senha);

            if (usuario != null)
            {
                Console.WriteLine($"Login bem-sucedido! Bem-vindo, {usuario.Nome}!");
                return usuario;
            }
            Console.WriteLine("Credenciais inválidas. Verifique o Email e a Senha.");
            return null;
        }
    }
}