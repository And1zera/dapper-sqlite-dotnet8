using dapperdotnet8.Domain.Interfaces.Context;
using System.Threading.Tasks;

namespace dapperdotnet8.Domain.Interfaces.Repository
{
    public interface IUnitOfWork
    {
        //classes
        IUserRepository UserRepository { get; }

        //methods
        IDbContext DbContext { get; }
        void Commit();
        void Rollback();
        void BeginTransaction();
    }
}