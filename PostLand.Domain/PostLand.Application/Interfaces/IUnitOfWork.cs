namespace PostLandApplication.Interfaces
{
    public interface IUnitOfWork
    {
        #region Transaction
        void BeginTransaction();
        void Commit();
        void RollBack();
        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollBackAsync();
        #endregion
        #region SaveChanges
        void SaveChanges();
        Task SaveChangesAsync();
        #endregion
    }
}
