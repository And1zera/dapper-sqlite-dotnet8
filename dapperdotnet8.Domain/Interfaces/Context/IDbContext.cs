using System.Data;

namespace dapperdotnet8.Domain.Interfaces.Context
{
    public interface IDbContext : IDisposable
    {
        IDbConnection Connection { get; }
    }
}