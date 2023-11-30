using Dapper.Contrib.Extensions;
using TarefaApi.Data;
using static TarefaApi.Data.TarefasContext;

namespace TarefaApi.Endpoints;

public static class TarefasEndpoints
{
    public static void MapTarefasEndpoints(this WebApplication app) 
    {
        app.MapGet("/", () => "Bem vindo a API Tarefas.");

        app.MapGet("/tarefas", async (GetConnection getConnection) =>
        {
            using var conn = await getConnection();
            var tarefas = conn.GetAll<Tarefa>().ToList();
            if (tarefas is null) return Results.NotFound();
            return Results.Ok(tarefas);
        });
    }
}