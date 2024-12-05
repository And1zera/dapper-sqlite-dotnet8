using dapperdotnet8.Domain.Interfaces.Context;
using dapperdotnet8.Domain.Interfaces.Repository;
using System.Data;

namespace dapperdotnet8.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        //contexts
        private readonly IDbContext _dbContext;
        private IDbTransaction _transaction;

        //repositorys
        private IUserRepository _userRepository;


        public UnitOfWork(IDbContext dbContext)
        {
            //constructor
            _dbContext = dbContext;

            //repositoryInject

        }

        public IDbContext DbContext => _dbContext;
        public void Commit()
        {
            _transaction?.Commit();
            Dispose();
        }

        public void Rollback()
        {
            _transaction?.Rollback();
            Dispose();
        }
        public void BeginTransaction()
        {
            _transaction = _dbContext.Connection.BeginTransaction();
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _dbContext?.Dispose();
        }

        //injections
        public IUserRepository UserRepository => _userRepository ?? (_userRepository = new UserRepository(_dbContext.Connection, _transaction));
    }
}