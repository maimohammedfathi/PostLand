using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using PostLandApplication.Interfaces;
using PostLandInfrastructure.Context;

namespace PostLand.Infrastructure.UnitOfWork
{

    public class UnitOfWork : IUnitOfWork
    {
        private readonly PostDbContext _postDbContext;
        private IDbContextTransaction _transaction;
        IServiceProvider _serviceProvider;
        //public Guid _loggedInUserId;

        public UnitOfWork(PostDbContext postDbContext, IServiceProvider serviceProvider/*, IHttpContextAccessor _httpContextAccessor*/)
        {
            _postDbContext=postDbContext;
            _serviceProvider=serviceProvider;
        }
        #region Transaction 
        public void BeginTransaction() => _transaction = _postDbContext.Database.BeginTransaction();

        public async Task BeginTransactionAsync() => _transaction = await _postDbContext.Database.BeginTransactionAsync();

        public void Commit() => _transaction.Commit();

        public async Task CommitAsync() => await _transaction.CommitAsync();

        public void RollBack() => _transaction.Rollback();

        public async Task RollBackAsync() => await _transaction.RollbackAsync();
        #endregion

        #region SaveChanges
        public void SaveChanges()
        {
            if (_postDbContext.Database.CurrentTransaction == null)
                BeginTransaction();
            _postDbContext.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            if (_postDbContext.Database.CurrentTransaction == null)
              await  BeginTransactionAsync();
           await _postDbContext.SaveChangesAsync();
        }
        #endregion 
    }
}

