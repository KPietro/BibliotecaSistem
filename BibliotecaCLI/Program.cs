using BibliotecaCLI.Models;
using BibliotecaCLI.Services;
using System;

namespace BibliotecaCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            var livroService = new LivroService();
            var usuarioService = new UsuarioService();
            var emprestimoService = new EmprestimoService();

            Usuario? usuarioLogado = null;

            Console.WriteLine("Bem-vindo ao Sistema de Biblioteca CLI!");

            // Substitua o bloco 'while(true)' existente por este:

            while (true)
            {
                if (usuarioLogado == null)
                {
                    // === MENU DESLOGADO (Cor Padrão) ===
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");
                    Console.WriteLine("*-* BEM-VINDO (Deslogado) *-*");
                    Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");
                    Console.ResetColor();

                    Console.WriteLine("» 1 - Fazer Login");
                    Console.WriteLine("» 2 - Cadastrar Novo Usuário");
                    Console.WriteLine("» 3 - Listar Todos os Usuários");

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("» 0 - Sair do Sistema");
                    Console.ResetColor();

                    Console.Write("Escolha sua opção: ");
                    string opc = Console.ReadLine()!;

                    switch (opc)
                    {
                        case "1":
                            usuarioLogado = usuarioService.Login();
                            break;
                        case "2":
                            usuarioService.CadastrarUsuario();
                            break;
                        case "3":
                            usuarioService.ListarUsuarios();
                            break;
                        case "0":
                            return;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");
                    Console.WriteLine($"*-* Logado como: {usuarioLogado.Nome.ToUpper()} *-*");
                    Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("    »»» EMPRÉSTIMOS E DEVOLUÇÕES «««");
                    Console.ResetColor();
                    Console.WriteLine("» 1 - Emprestar Livro");
                    Console.WriteLine("» 2 - Devolver Livro");
                    Console.WriteLine("» 3 - Listar Meus Empréstimos Ativos");
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("\n    »»» GESTÃO DE LIVROS «««");
                    Console.ResetColor();
                    Console.WriteLine("» 4 - Listar Livros Disponíveis");
                    Console.WriteLine("» 5 - Listar Todos os Livros");
                    Console.WriteLine("» 6 - Cadastrar Novo Livro");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n» 9 - Logout (Sair da conta)");
                    Console.ResetColor();

                    Console.Write("Escolha sua opção: ");
                    string opc = Console.ReadLine()!;

                    switch (opc)
                    {
                        case "1":
                            emprestimoService.EmprestarLivro(usuarioLogado);
                            break;
                        case "2":
                            emprestimoService.DevolverLivro(usuarioLogado);
                            break;
                        case "3":
                            emprestimoService.ListarMeusEmprestimos(usuarioLogado);
                            break;
                        case "4":
                            livroService.ListarLivrosDisponiveis();
                            break;
                        case "5":
                            livroService.ListarTodosLivros();
                            break;
                        case "6":
                            livroService.CadastrarLivro();
                            break;
                        case "9":
                            usuarioLogado = null;
                            Console.WriteLine("Logout realizado com sucesso!");
                            break;
                    }
                }
            }
        }
    }
}