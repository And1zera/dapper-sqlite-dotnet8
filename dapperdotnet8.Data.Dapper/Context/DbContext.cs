using dapperdotnet8.Application.Utils;
using dapperdotnet8.Domain.Interfaces.Context;
using Microsoft.Data.Sqlite;
using System.Data;


namespace dapperdotnet8.Data.Dapper.Context
{
    public class DbContext : IDbContext
    {
        private readonly IDbConnection _connection;

        public DbContext()
        {
            var connectionString = ConnectionStringBuilder.BuildFromEnvironment();

            _connection = new SqliteConnection(connectionString);

            _connection.Open();
        }

        public IDbConnection Connection => _connection;

        public void Dispose()
        {
            _connection?.Dispose();
        }
    }
}
