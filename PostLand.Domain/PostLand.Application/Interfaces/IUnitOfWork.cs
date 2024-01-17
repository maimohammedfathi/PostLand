namespace PostLandApplication.Interfaces
{
    public interface IUnitOfWork
    {
        #region Transaction
        void BeginTransaction();
        void Commit();
        void RollBack();
        #endregion
        #region SaveChanges
        void SaveChanges();
        #endregion
    }
}
