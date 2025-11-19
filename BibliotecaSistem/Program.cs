using BibliotecaSistem.Services;
using System;

namespace BibliotecaSistem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando Sistema de Biblioteca...");

            // 1. Instancia nosso serviço
            var service = new BibliotecaService();

            // 2. Tenta cadastrar um livro de teste
            Console.WriteLine("Cadastrando um livro de teste...");
            service.CadastrarLivro("O Senhor dos Anéis", "J.R.R. Tolkien", 1200, "SN-001");

            // 3. Lista para ver se salvou
            service.ListarLivros();

            // Mantém a tela aberta
            Console.ReadKey();
        }
    }
}