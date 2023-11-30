using System.Data.SqlClient;

namespace TarefaApi.Extensions;

public static class ServiceCollectionsExtensions
{
    public static WebApplicationBuilder AddPersistence(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

        builder.Services.AddScoped<Data.TarefasContext.GetConnection>(sp =>
        async () =>
        {
            var connection = new SqlConnection(connectionString);
            await connection.OpenAsync();
            return connection;
        });
        return builder;
    }
}