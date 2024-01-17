using PostLandApplication.Interfaces;

namespace PostLand.Infrastructure.UnitOfWork
{

    public class UnitOfWork : IUnitOfWork
    {
        public void BeginTransaction()
        { }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void RollBack()
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
