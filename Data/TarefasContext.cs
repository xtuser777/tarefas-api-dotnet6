using System.Data;

namespace TarefaApi.Data;

public class TarefasContext
{
    public delegate Task<IDbConnection> GetConnection();
}