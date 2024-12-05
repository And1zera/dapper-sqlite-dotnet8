using System.Data;
using Dapper;
using dapperdotnet8.Domain.Interfaces.Repository;
using static Dapper.SqlMapper;

namespace dapperdotnet8.Data.Dapper.Repository
{
    public class BaseRepository<T>(IDbConnection connection, IDbTransaction transaction) : IBaseRepository<T> where T : class
    {
        readonly string tableName = typeof(T).Name;

        // Método para buscar todos os registros
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var query = $"SELECT * FROM {tableName} WHERE removed <> true;";
            return await connection.QueryAsync<T>(query, transaction);
        }

        // Método para buscar um registro por ID
        public async Task<T?> GetByIdAsync(string id)
        {
            var query = $"SELECT * FROM {tableName} WHERE Id = @Id AND removed <> true;";
            return await connection.QueryFirstOrDefaultAsync<T>(query, new { Id = id }, transaction);
        }

        // Método para inserir um registro
        public async Task<int> InsertAsync(T entity)
        {
            var query = GenerateInsertQuery(tableName, entity);
            return await connection.ExecuteAsync(query, entity, transaction);
        }

        // Método para atualizar um registro
        public async Task<int> UpdateAsync(T entity)
        {
            var query = GenerateUpdateQuery(tableName, entity);
            return await connection.ExecuteAsync(query, entity, transaction);
        }

        // Método para excluir um registro
        public async Task<int> DeleteAsync(T entity)
        {
            var query = GenerateUpdateQuery(tableName, entity);
            return await connection.ExecuteAsync(query, entity, transaction);
        }

        // Método auxiliar para gerar query de inserção
        private string GenerateInsertQuery(string tableName, T entity)
        {
            var properties = typeof(T).GetProperties();
            var columns = string.Join(", ", properties.Select(p => p.Name));
            var values = string.Join(", ", properties.Select(p => "@" + p.Name));

            return $"INSERT INTO {tableName} ({columns}) VALUES ({values});";
        }

        // Método auxiliar para gerar query de atualização
        private string GenerateUpdateQuery(string tableName, T entity)
        {
            var properties = typeof(T).GetProperties();
            var setClause = string.Join(", ", properties.Select(p => $"{p.Name} = @{p.Name}"));

            return $"UPDATE {tableName} SET {setClause} WHERE Id = @ID;";
        }
    }
}
