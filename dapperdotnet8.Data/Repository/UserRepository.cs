using dapperdotnet8.Data.Dapper.Repository;
using dapperdotnet8.Domain.Entity;
using dapperdotnet8.Domain.Interfaces.Repository;
using System.Data;

namespace dapperdotnet8.Data.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(IDbConnection connection, IDbTransaction transaction) : base(connection, transaction)
        {
        }
    }
}
