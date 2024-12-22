using System.Data;
using HouseRent.Core.ApplicationServices.Contracts;
using Microsoft.Data.SqlClient;

namespace HouseRent.Infra.Data.Sql.Command.ConnectionFactory;

internal sealed class SqlConnectionFactory(string connectionString) : ISqlConnectionFactory
{
    private readonly string _connectionString = connectionString;

    public IDbConnection CreateConnection()
    {
        var connection = new SqlConnection(_connectionString);
        connection.Open();

        return connection;
    }
}