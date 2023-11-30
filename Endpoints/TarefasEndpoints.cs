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

        app.MapGet("/tarefas/{id}", async (GetConnection getConnection, int id) =>
        {
            using var conn = await getConnection();
            var tarefa = conn.Get<Tarefa>(id);
            if (tarefa is null) return Results.NotFound();
            return Results.Ok(tarefa);
        });

        app.MapPost("/tarefas", async (GetConnection getConnection, Tarefa Tarefa) =>
        {
            using var conn = await getConnection();
            var id = conn.Insert(Tarefa);
            return Results.Created($"/tarefas/{id}", Tarefa);
        });

        app.MapPut("/tarefas", async (GetConnection getConnection, Tarefa Tarefa) =>
        {
            using var conn = await getConnection();
            var id = conn.Update(Tarefa);
            return Results.Ok();
        });

        app.MapDelete("/tarefas/{id}", async (GetConnection getConnection, int id) =>
        {
            using var conn = await getConnection();
            var tarefa = conn.Get<Tarefa>(id);
            if (tarefa is null) return Results.NotFound();
            conn.Delete(tarefa);
            return Results.Ok(tarefa);
        });
    }
}