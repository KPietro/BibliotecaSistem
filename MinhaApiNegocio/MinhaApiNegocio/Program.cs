using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace MinhaApiConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // Cria e configura o servidor Web
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            // Lista em memória
            var tarefas = new List<string>();

            // Endpoint GET
            app.MapGet("/tarefas", () => Results.Ok(tarefas));

            // Endpoint POST
            app.MapPost("/tarefas", (string tarefa) =>
            {
                tarefas.Add(tarefa);
                return Results.Created($"/tarefas/{tarefas.Count - 1}", tarefa);
            });

            // Endpoint DELETE
            app.MapDelete("/tarefas/{id:int}", (int id) =>
            {
                if (id < 0 || id >= tarefas.Count)
                    return Results.NotFound("Tarefa não encontrada.");

                tarefas.RemoveAt(id);
                return Results.Ok("Tarefa removida com sucesso.");
            });

            // Exibe mensagem no console
            Console.WriteLine("🚀 API rodando em: https://localhost:5001 ou http://localhost:5000&quot;);

            // Inicia o servidor (bloqueante)
            app.Run();
        }
    }
}